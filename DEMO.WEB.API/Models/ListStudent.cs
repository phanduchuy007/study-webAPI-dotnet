using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DEMO.WEB.API.Models
{
	public class ListStudent
	{
		public static List<ListStudent> listStudents = new List<ListStudent>() {
			new ListStudent(){ StudentName = "Huy Phan", Emai="huy@gmail.com", Phone="0123456789"},
			new ListStudent(){ StudentName = "Huy Phan 1", Emai="huy1@gmail.com", Phone="0123456789"},
			new ListStudent(){ StudentName = "Huy Phan 2", Emai="huy2@gmail.com", Phone="0123456789"},
		};

		public string StudentName { get; set; }
		public string Emai { get; set; }
		public string Phone { get; set; }
	}
}