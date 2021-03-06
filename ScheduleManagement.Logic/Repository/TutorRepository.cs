﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScheduleManagement.Logic.Model;


namespace ScheduleManagement.Logic.Repository
{

    public class TutorRepository : Repository<Tutor>
    {
        public event Action<string> Message;

        public TutorRepository(Context context) : base(context)
        {
            Items = context.Tutors.ToList();
        }

        Authorization authorization = new Authorization();

        public bool EmailExists(string email)
        {
            return _context.Set<Tutor>().Any(t => t.Email == email);
        }

        public bool PasswordIsValid(string email, string password)
        {
            string passwordHash = authorization.CalculateHash(password);
            return _context.Set<Tutor>().Any(t => t.Email == email && t.Password == passwordHash);
        }

        public void AddTutor(Tutor tutor)
        {
            _context.Set<Tutor>().Add(tutor);
        }

        public bool CheckRegistration(string name, string surname, string email, string password)
        {
            if (String.IsNullOrWhiteSpace(email) || String.IsNullOrWhiteSpace(password) || String.IsNullOrWhiteSpace(name) || String.IsNullOrWhiteSpace(surname))
            {
                Message?.Invoke("Введите данные");
                return false;
            }
            else   if (EmailExists(email))
                {
                    Message?.Invoke("Пользователь с таким email уже зарегистрирован в системе");
                    return false;
                }
                else
                {
                    Register(name, surname, email, password);
                    return true;
                }
            
        }

        public void Register(string name, string surname, string email, string password)
        {
            string passwordHash = authorization.CalculateHash(password);
            Tutor tutor = new Tutor()
            { Name = name, Surname = surname, Email = email, Password = passwordHash };
            AddTutor(tutor);
            _context.SaveChanges();
            Message?.Invoke("Вы успешно зарегистрированы");

        }


        public bool CheckLogin(string email, string password)
        {
            if (String.IsNullOrWhiteSpace(email) || String.IsNullOrWhiteSpace(password))
            {
                Message?.Invoke("Введите данные");
                return false;
            }
            else   if (!EmailExists(email))
                {
                    Message?.Invoke("Почта не зарегистрирована в системе");
                    return false;
                }
            else if (!PasswordIsValid(email, password))
                    {
                        Message?.Invoke("Введен неверный пароль");
                        return false;
                    }
             else
                    {
                Storage.Default.CurrentID = SaveLogin(email);
                return true;
                    }
                
            
        }

        public int SaveLogin(string email)
        {
            return _context.Set<Tutor>().First(x => x.Email == email).ID;
        }
    }
}
