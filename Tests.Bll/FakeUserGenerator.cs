using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Bogus;
using Tests.Dal.Models;
using static Bogus.DataSets.Name;

namespace Tests.Bll
{
    public static class FakeUserGenerator
    {
        public static Employee GetFakeUser(List<Position> positions)
        {
            Random r = new Random();
            Gender gender = r.Next(0, 1) == 0 ? Gender.Male : Gender.Female;
            Employee emp = new Faker<Employee>()
                .RuleFor(x => x.AvatarId, x => 1)
                .RuleFor(x => x.FirstName, x => x.Name.FirstName(gender))
                .RuleFor(x => x.PositionId, x => positions[r.Next(0, positions.Count-1)].Id)
                .RuleFor(x => x.SurName, x => x.Name.LastName(gender))
                .RuleFor(x => x.Email, (x, y) => x.Internet.Email(y.FirstName, y.SurName))
                .RuleFor(x => x.IsCandidate, r.Next(0, 1) == 0 ? true : false)
                .RuleFor(x => x.Phone, x => x.Phone.PhoneNumber());
            return emp;
        }
    }


}
