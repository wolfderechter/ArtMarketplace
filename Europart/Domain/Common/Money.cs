using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EuropArt.Domain.Common
{
    public class Money : ValueObject
    {
        public decimal Value { get;}

        public Money(decimal value)
        {
            Value = value;
        }
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Math.Round(Value, 2);
        }

        public static implicit operator decimal(Money money) => money.Value;
        public static implicit operator Money(decimal value) => new Money(value);
    }
}
