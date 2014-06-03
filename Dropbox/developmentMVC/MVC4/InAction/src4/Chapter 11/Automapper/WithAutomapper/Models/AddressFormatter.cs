using AutoMapper;
using Core.Model;

namespace WithAutomapper.Models
{
	public class AddressFormatter : ValueFormatter<Address>
	{
		protected override string FormatValueCore(Address value)
		{
			string withSecondLine = string.Format("{0} {1}, {2}, {3} {4}",
			                                      value.Line1, value.Line2, value.City, value.State, value.Zip);
			string withoutSecondLine = string.Format("{0} {1}, {2} {3}",
			                                         value.Line1, value.City, value.State, value.Zip);
			string address = string.IsNullOrEmpty(value.Line2) ? withoutSecondLine : withSecondLine;
			address = string.IsNullOrEmpty(value.Line1) ? string.Empty : address;

			return address;
		}
	}
}