// -- FILE ------------------------------------------------------------------
// name       : Customer.cs
// created    : Jani Giannoudis - 2008.05.09
// language   : c#
// environment: .NET 3.0
// --------------------------------------------------------------------------

namespace Itenso.Solutions.Community.ConfigurationWindowsDemo
{

	// ------------------------------------------------------------------------
	public class Customer
	{

		// ----------------------------------------------------------------------
		public Customer()
		{
		} // Customer

		// ----------------------------------------------------------------------
		public Customer( string firstName, string lastName, string street, 
			string city, string zipCode )
		{
			FirstName = firstName;
			LastName = lastName;
			Street = street;
			City = city;
			ZipCode = zipCode;
		} // Customer

		// ----------------------------------------------------------------------
		public string FirstName { get; set; }

		// ----------------------------------------------------------------------
		public string LastName { get; set; }

		// ----------------------------------------------------------------------
		public string Street { get; set; }

		// ----------------------------------------------------------------------
		public string City { get; set; }

		// ----------------------------------------------------------------------
		public string ZipCode { get; set; }

	} // class Customer

} // namespace Itenso.Solutions.Community.ConfigurationWindowsDemo
// -- EOF -------------------------------------------------------------------
