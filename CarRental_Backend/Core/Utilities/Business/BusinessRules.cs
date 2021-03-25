using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Business
{
    public class BusinessRules
    {
        public static List<IResult> Run(params IResult[] logics)
        {
            List<IResult> errorResults = new List<IResult>();
            foreach (var logic in logics)
            {
                if (!logic.Success)
                {
                    errorResults.Add(logic);
                }
            }
            return errorResults;
        }


    }
}
