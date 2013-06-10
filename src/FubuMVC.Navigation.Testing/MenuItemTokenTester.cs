using System;
using FubuTestingSupport;
using NUnit.Framework;

namespace FubuMVC.Navigation.Testing
{
	[TestFixture]
	public class MenuItemTokenTester
	{
		[Test]
		public void get_data()
		{
			var token = new MenuItemToken();
			var value = Guid.NewGuid();

			token.Data.Add("Test", value);

			token.Get<Guid>("Test").ShouldEqual(value);
		}

		[Test]
		public void has_data()
		{
			var token = new MenuItemToken();
			var value = Guid.NewGuid();

			token.Data.Add("Test", value);

			token.Has("Test").ShouldBeTrue();
		}

		[Test]
		public void value_continuation_for_existing_value()
		{
			var token = new MenuItemToken();
			var expected = Guid.NewGuid();

			token.Set("key", expected);

			token.Value<Guid>("key", x => x.ShouldEqual(expected));
		}

		[Test]
		public void value_continuation_for_non_existing_value()
		{
			var token = new MenuItemToken();
			var invoked = false;

			token.Value<Guid>("key", x => invoked = true);

			invoked.ShouldBeFalse();
		}
	}
}