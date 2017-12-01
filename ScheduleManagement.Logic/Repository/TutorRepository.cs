using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScheduleManagement.Logic.Model;
using ScheduleManagement.Logic.Interfaces;

namespace ScheduleManagement.Logic.Repository
{
    public class TutorRepository : Repository<Tutor>, ITutorRepository
    {
        public event Action<string> Message;

        public TutorRepository(Context context) : base(context)
        {
            Items = context.Tutors.ToList();
        }


        Authorization authorization = new Authorization();


        public IEnumerable<Tutor> CheckEmail(string email)
        {
            return _context.Set<Tutor>().Where(t => t.Email == email).AsEnumerable<Tutor>();
        }

        public IEnumerable<Tutor> CheckPassword(string email, string password)
        {
            string passwordHash = authorization.CalculateHash(password);
            return _context.Set<Tutor>().Where(t => t.Email == email && t.Password == passwordHash).AsEnumerable<Tutor>();
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
            else
            {
                if (CheckEmail(email).Count<Tutor>() != 0)
                {
                    Message?.Invoke("Пользователь с таким email уже зарегистрирован в системе");
                    return false;
                }
                else
                {
                    string passwordHash = authorization.CalculateHash(password);
                    Tutor tutor = new Tutor()
                    { Name = name, Surname = surname, Email = email, Password = passwordHash };
                    AddTutor(tutor);
                    _context.SaveChanges();
                    Message?.Invoke("Вы успешно зарегистрированы");

                    return true;
                }

            }
        }








        public bool CheckLogin(string email, string password)
        {
            if (String.IsNullOrWhiteSpace(email) || String.IsNullOrWhiteSpace(password))
            {
                Message?.Invoke("Введите данные");
                return false;
            }
            else
            {
                if (CheckEmail(email).Count<Tutor>() == 0)
                {
                    Message?.Invoke("Почта не зарегистрирована в системе");
                    return false;
                }
                else
                {
                    if (CheckPassword(email, password).Count<Tutor>() == 0)
                    {
                        Message?.Invoke("Введен неверный пароль");
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
            }
        }

        public int SaveLogin(string email)
        {
            return CheckEmail(email).First(x => x.Email == email).ID;

        }

        public void FormSchedule(DateTime? date)
        {
            if (date==null)
            {
                //мне лень писать запрос
            }
        }

    }
}
