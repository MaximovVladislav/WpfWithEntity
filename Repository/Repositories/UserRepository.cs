using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Model;

namespace Repository.Repositories
{
    public class UserRepository : IRepository<User>
    {
        public User Create()
        {
            using (var context = new MyContext())
            {
                User user = context.Users.Create<User>();
                context.Users.Add(user);
                context.SaveChanges();

                return context.Users.SingleOrDefault(x => user.Id == x.Id);
            }

        }

        public IEnumerable<User> GetAll()
        {
            using (var context = new MyContext())
            {
                return context.Users.ToList();
            }
        }

        public void Update(User entity)
        {
            using (var context = new MyContext())
            {
                var original = context.Users.SingleOrDefault(x => x.Id == entity.Id);

                if (original != null)
                {
                    original.FirstName = entity.FirstName;
                    original.LastName = entity.LastName;
                    original.DateOfBirth = entity.DateOfBirth;

                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Пользователь удален. Обновите, чтобы получить актуальные данные.");
                }
            }
        }

        public bool Delete(User entity)
        {
            using (var context = new MyContext())
            {
                try
                {
                    User user = context.Users.SingleOrDefault(x => x.Id == entity.Id);

                    if (user == null)
                    {
                        throw new Exception("Пользователь уже удален. Обновите, чтобы получить актуальные данные.");
                    }

                    user = context.Users.Remove(user);
                    context.SaveChanges();
                    if (user != null) return true;

                    return false;
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    throw new Exception(
                        "Коллекция пользователей изменена в другом экземпляре программы. Обновите, чтобы получить актуальные данные.",
                        ex);
                }
            }
        }
    }
}
