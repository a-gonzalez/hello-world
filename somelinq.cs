using System;
//using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Xml.Linq;

namespace Unus
{
	public static class Applet
	{
		static void Main(string[] arguments) // public delegate bool Predicate<in T>(T obj);
		{
			Predicate<string> isUpper = delegate(string s) { return s.Equals(s.ToUpper()); };
			Predicate<string> esUpper = s => s.Equals(s.ToUpper());
			
			List<Process> processes = GetProcessList();
			
			foreach(Process process in processes)
			{
				Console.WriteLine("Process: {0}", process.ProcessName);
			}
			
			IEnumerable<string> numbers = GetNumbers();
			
			foreach(string number in numbers)
			{
				Console.WriteLine("Number: {0}", number);
			}
			
			IEnumerable<string> colors = GetColors();
			
			foreach(string color in colors)
			{
				Console.WriteLine("Color: {0}", color);
			}
		}
		
		private static List<Process> GetProcessList(string filter = null)
		{
			List<Process> list = new List<Process>(Process.GetProcesses());
			/*List<Process> list = from process in Process.GetProcesses()
									orderby process.ProcessName ascending
									select process;*/
			
			if (filter != null) // filter
			{
				list = list.FindAll(delegate(Process process)
				{
					return String.Equals(filter, process.ProcessName);
				});
			}
			
			list.Sort(delegate(Process a, Process b)
			{
				//return b.WorkingSet64.CompareTo(a.WorkingSet64);
				return a.ProcessName.CompareTo(b.ProcessName);
			});

			return list;
		}
		
		private static IEnumerable<string> GetNumbers()
		{
			IEnumerable<string> numbers = new string[] {"Unus", "Duo", "Tres", "Quattuor", "Quinque"};
			
			return numbers;
		}
		
		private static IEnumerable<string> GetColors()
		{
			string xml = @"<colors>
				<color>Blue</color>
				<color>Yellow</color>
				<color>Green</color>
				<color>Purple</color>
				<color>Pink</color>
				<color>Orange</color>
			</colors>";
			
			XElement element = XElement.Parse(xml);
			
			IEnumerable<string> colors = from n in element.Elements("color")
										//where n.Value == "Purple" || n.Value == "Blue"
										orderby n.Value descending
										select n.Value;
			
			return colors;
		}
		
		private static void ProcessItems(List<Process> items)
		{
			foreach(var item in items)
			{
				Console.WriteLine(item);
			}
			/*IEnumerable<string> ns = from n in numbers
										where n.Length >= 4
										orderby n descending
										select n;*/
										
		}
	}
}	
