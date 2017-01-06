// -- FILE ------------------------------------------------------------------
// name       : Program.cs
// created    : Jani Giannoudis - 2008.04.25
// language   : c#
// environment: .NET 2.0
// --------------------------------------------------------------------------
using System;
using Itenso.Configuration;

namespace Itenso.Solutions.Community.ConfigurationConsoleDemo
{

	// ------------------------------------------------------------------------
	class Program
	{

		// ----------------------------------------------------------------------
		[PropertySetting( DefaultValue=-1 )]
		public int StatusCode { get; set; }

		// ----------------------------------------------------------------------
		public void Execute()
		{
			// setup and load user settings
			ApplicationSettings settings = new ApplicationSettings( this );
			settings.Load();

			// show startup values
			Console.WriteLine( "Status-Code value: " + StatusCode );
			Console.WriteLine( "Status-Code setting: " + settings[ "StatusCode" ] );
			Console.WriteLine();

			// user input
			Console.Write( "Please enter a number (Enter to reset): " );
			string consoleInput = Console.ReadLine();
			if ( string.IsNullOrEmpty( consoleInput ) )
			{
				settings.Reset();
			}
			else
			{
				try
				{
					StatusCode = int.Parse( consoleInput ); // modifying the field value
				}
				catch 
				{
					Console.Write( "Invalid input. Press any key..." );
					Console.ReadKey();
					return;
				}
			}

			// save user settings
			settings.Save();
			Console.WriteLine();
			Console.WriteLine( "Settings saved to: " + ApplicationSettings.UserConfigurationFilePath );

			// show working values
			Console.WriteLine();
			Console.WriteLine( "Status-Code value: " + StatusCode );
			Console.WriteLine( "Status-Code setting: " + settings[ "StatusCode" ] );

			Console.WriteLine();
			Console.Write( "Press any key..." );
			Console.ReadKey();
		} // Execute

		// ----------------------------------------------------------------------
		static void Main()
		{
			new Program().Execute();
		} // Main

	} // class Program

} // namespace Itenso.Solutions.Community.ConfigurationConsoleDemo
// -- EOF -------------------------------------------------------------------
