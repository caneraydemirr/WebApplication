using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class MyViewModel
    {
        public MyViewModel(List<Orders> orderList, List<Customers> customerList, List<Employees> employeeList)
        {
            this.orderList = orderList;
            this.customerList = customerList;
            this.employeeList = employeeList;
        }
        public List<Orders> orderList { get; set; }
        public List<Customers> customerList { get; set; }
        public List<Employees> employeeList { get; set; }
    }
}
