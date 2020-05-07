using System;

namespace CA.Infrastructure.Common.IOC.Factories
{
    public class EmployeeSearchStrategyFactory
    {
        public static Func<string, string, bool> GetStringStrategy(string strategyName)
        {
            switch(strategyName)
            {
                case "ContainsStrategy":
                    return (target, value) => target.Contains(value);
                default:
                    throw new ArgumentException();
            }
        }


        public static Func<int, int, bool> GetIntStrategy(string strategyName)
        {
            switch(strategyName)
            {
                case "GreaterThanSearch":
                    return (target, value) => target > value;
                default:
                    throw new ArgumentException();
            }
        }
    }
}
