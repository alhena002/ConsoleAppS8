using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppS8
{
    internal class Program
    {
        public static DataClasses1DataContext context = new DataClasses1DataContext();
        static void Main(string[] args)
        {
            // IntroLINQ();
            // DataSource();
            // Filtering();
            // Ordering();
            // Grouping();
            // Grouping2();
            // Joining();

            Console.WriteLine("-----------------------------------------------------------------------------------------------");

            IntroLINQLambda();
            DataSourceLambda();
            FilteringLambda();
            OrderingLambda();
            GroupingLambda();
            Grouping2Lambda();
            JoiningLambda();

            Console.Read();
        }

        /*
        static void IntroLINQ()
        {

            int[] numbers = new int[7] { 0, 1, 2, 3, 4, 5, 6 };
            var numQuery = from num in numbers where (num % 2) == 0 select num;
            foreach (int num in numQuery)
            {
                Console.Write("{0,1} ", num);
            }
           
        }
        */

        /*
        static void DataSource()
        {
       
            var queryAllCustomers = from cust in context.clientes select cust;
            foreach (var item in queryAllCustomers)
            {
                Console.WriteLine(item.NombreCompa_ia);
            }

        }
        */

        /*
        static void Filtering()
        {
            
            var queryLondonCustomers = from cust in context.clientes where cust.Ciudad == "Londres" select cust;

            foreach (var item in queryLondonCustomers)
            {
                Console.WriteLine(item.Ciudad);
            }
        }
        */

        /*
        static void Ordering()
        {
         
            var queryLondonCustomers3 = from cust in context.clientes
                                        where cust.Ciudad == "Londres"
                                        orderby cust.NombreCompa_ia ascending
                                        select cust;

            foreach (var item in queryLondonCustomers3)
            {
                Console.WriteLine(item.NombreCompa_ia);
            }

        }
        */

        /*
        static void Grouping()
        {
           
            var queryCustomerByCity = from cust in context.clientes group cust by cust.Ciudad;

            foreach (var customerGroup in queryCustomerByCity)
            {
                Console.WriteLine(customerGroup.Key);
                foreach (clientes customer in customerGroup)
                { 
                    Console.WriteLine("     {0}", customer.NombreCompa_ia);
                }
            }

        }
        */
        
        /*        
        static void Grouping2()
        {
          
            var custQuery = from cust in context.clientes
                            group cust by cust.Ciudad into custGroup
                            where custGroup.Count() > 2
                            orderby custGroup.Key
                            select custGroup;
            foreach (var item in custQuery)
            { 
                Console.WriteLine(item.Key);
            }

        }
        
        */
        
        /*
        static void Joining()
        {
         
            var innerJoinQuery = from cust in context.clientes
                                 join dist in context.Pedidos on cust.idCliente equals dist.IdCliente
                                 select new { 
                                     CustomerName = cust.NombreCompa_ia,
                                     DistributorName = dist.PaisDestinatario 
                                 };
            foreach (var item in innerJoinQuery)
            {
                Console.WriteLine(item.CustomerName);
            }
        }
        */
        
        // -------------------------------------------------------------------------------------------------------------------------------
        
        static void IntroLINQLambda()
        {

            int[] numbers = new int[7] { 0, 1, 2, 3, 4, 5, 6 };
            var numQuery = numbers.Where(n => n % 2 == 0).Select(n => n);

            foreach (int num in numQuery)
            {
                Console.Write("{0,1} ", num);
            }

        }
        
        static void DataSourceLambda()
        {
            var queryAllCustomers = context.clientes.Select(c => c);

            foreach (var item in queryAllCustomers)
            {
                Console.WriteLine(item.NombreCompa_ia);
            }

        }

        static void FilteringLambda()
        {
            var queryLondonCustomers = context.clientes.Where(c => c.Ciudad == "Londres").Select(c => c).ToList();

            foreach (var item in queryLondonCustomers)
            {
                Console.WriteLine(item.Ciudad);
            }
        }
                
        static void OrderingLambda()
        {
            var queryLondonCustomers3 = context.clientes.Where(c => c.Ciudad == "Londres").OrderBy(c => c.NombreCompa_ia).Select(c => c);

            foreach (var item in queryLondonCustomers3)
            {
                Console.WriteLine(item.NombreCompa_ia);
            }

        }
                
        static void GroupingLambda()
        {
            var queryCustomerByCity = context.clientes.GroupBy(c => c.Ciudad);

            foreach (var customerGroup in queryCustomerByCity)
            {
                Console.WriteLine(customerGroup.Key);
                foreach (clientes customer in customerGroup)
                { 
                    Console.WriteLine("     {0}", customer.NombreCompa_ia);
                }
            }

        }

        static void Grouping2Lambda()
        {            
            var custQuery = context.clientes.GroupBy(c => c.Ciudad).Where(c => c.Count() > 2).OrderBy(c => c.Key).Select(c => c);    

            foreach (var item in custQuery)
            { 
                Console.WriteLine(item.Key);
            }

        }
 
        static void JoiningLambda()
        {
            var innerJoinQuery = context.clientes.Join(context.Pedidos, c => c.idCliente, d => d.IdCliente, (c, d) => new { CustomerName = c.NombreCompa_ia, DistributorName = d.PaisDestinatario });

            foreach (var item in innerJoinQuery)
            {
                Console.WriteLine(item.CustomerName);
            }


        }
        
    }

}
