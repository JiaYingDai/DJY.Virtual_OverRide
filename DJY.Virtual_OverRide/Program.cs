using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DJY.Virtual_OverRide
{
	internal class Program
	{
		//公司有人，有些人是員工
		//class person
		//class employee

		//員工有三種職位，本薪外領有不同種的工資
		//1. 工程師
		//class Engineer 領 overtimepay(加班費)

		//2. 業務
		//class Sales 領 bonus(紅利分潤)

		//3. 經理
		//class Manage 領 leaderBonus(領導加給)
		//--> leaderBonus 視 帶領的員工（Employee[] ）人數而定，領導一人10萬元

		//public CalSalary // 寫一個函數計算回傳所有人的薪資

		static void Main(string[] args)
		{
			var engineer = new Engineer { 
				Name = "A女", 
				BadgeNumber = "1", 
				Job = "工程師", 
				Salary = 23000, 
				OverTimeHour = 40, 
				OverTimePayPerHour = 200 };
			
			var sales = new Sales { 
				Name = "B女", 
				BadgeNumber = "2", 
				Job = "業務", 
				Salary = 23000, 
				Bonus = 20000 };
			
			var manager = new Manager { 
				Name = "C男", 
				BadgeNumber = "3", 
				Job = "經理", 
				TeamMember=10, 
				Salary = 23000, 
				LeaderBonus = 100000 };
			
			
			List<Employee> people = new List<Employee> { };
			people.Add(engineer);
			people.Add(sales);
			people.Add(manager);

			foreach (Employee item in people)
			{
				Console.WriteLine($"編號{item.BadgeNumber}: {item.Name}");
				Console.WriteLine($"職務: { item.Job}");
				Console.WriteLine($"薪資為{item.CalSalary()}\r\n");
			}


		}

	}

	public class Person
	{
        public string Name { get; set; }
		public string BadgeNumber { get; set; }
    }

	public class Employee:Person
	{
		public string Job { get; set; } // 職位名稱

		public int Salary { get; set; } // 本薪


		public virtual int CalSalary() // 計算總薪資
		{
			int totalSalary = this.Salary;

			return totalSalary;
		}


	}

	public class Engineer : Employee
	{
		public int OverTimeHour { get; set; } // 加班時數
        public int OverTimePayPerHour { get; set; } // 單位小時加班費

		public virtual int CalOverTimePay() // 計算加班費共多少
		{
			int overTimePay = this.OverTimeHour * OverTimeHour;

			return overTimePay;
		}
		
        public override int CalSalary() // 計算總薪資
		{
			int totalSalary = this.Salary + CalOverTimePay();
			
			return totalSalary;
		}

	}

	public class Sales : Employee
	{
        public int Bonus { get; set; } // 分紅
        public virtual int CalBonus() // 計算總分紅
		{
			int totalBonus=this.Bonus;

			return totalBonus;
		}

		public override int CalSalary() // 計算總薪資
		{
			int totalSalary = this.Salary + CalBonus();

			return totalSalary;

		}

	}



	public class Manager : Employee
	{
        public int LeaderBonus { get; set; } // 領導加給/人
		public int TeamMember { get; set; } // 領導團隊人數


		public virtual int CalMember() // 計算帶領人數
		{
			int teamMember = TeamMember;
			
			return teamMember;

		}

		
		public virtual int CalLeaderBonus() // 計算總加給
		{
			int totalLeaderBonus = this.LeaderBonus * CalMember();

			return totalLeaderBonus;
		}
        public override int CalSalary() // 計算總薪資
		{
			int totalSalary = this.Salary + CalLeaderBonus();

			return totalSalary;
		}

	}

}
