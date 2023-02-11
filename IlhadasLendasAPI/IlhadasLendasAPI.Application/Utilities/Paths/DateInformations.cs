using IlhadasLendasAPI.Domain.Enum;

namespace IlhadasLendasAPI.Application.Utilities.Paths
{
    public static class DateInformations
    {
        public static string GetSplitData(Date data)
        {
            DateTime datevalue = DateTime.Now;

            return data switch
            {
                Date.Year => datevalue.Year.ToString(),
                Date.Month => datevalue.Month.ToString(),
                Date.Day => datevalue.Day.ToString(),
                _ => null,
            };
        }
    }
}