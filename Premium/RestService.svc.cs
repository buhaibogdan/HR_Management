using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Premium
{
    public class RestService : IRestService
    {
        private List<Salary> salariesList;

        private void LoadSalaries()
        {
            salariesList = new List<Salary>{
                new Salary{
                    email = "bb@email.com",
                    GrossIncome = 1500,
                    NetIncome = 1200
                },
                new Salary{
                    email = "manager@email.com",
                    GrossIncome = 1900,
                    NetIncome = 1500
                },
                new Salary{
                    email = "employee@email.com",
                    GrossIncome = 800,
                    NetIncome = 600
                },
                new Salary{
                    email = "employee2@email.com",
                    GrossIncome = 700,
                    NetIncome = 530
                }
            };
        }

        public List<string> GetContributions()
        {
            List<string> contributions = new List<string> { 
                "CAS", "CASS", "Impozit pe venit", "Somaj"
            };

            return contributions;
        }

        public int GetNetIncome(string UsereEmail)
        {
            LoadSalaries();
            foreach (Salary sal in salariesList)
            {
                if (sal.email == UsereEmail)
                {
                    return sal.NetIncome;
                }
            }
            return 0; 
        }

        public int GetGrossIncome(string UsereEmail)
        {
            LoadSalaries();
            foreach (Salary sal in salariesList)
            {
                if (sal.email == UsereEmail)
                {
                    return sal.GrossIncome;
                }
            }
            return 0;
        }

    }
}
