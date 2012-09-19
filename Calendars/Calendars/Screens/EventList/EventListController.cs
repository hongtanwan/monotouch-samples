using System;
using System.Linq;
using System.Collections.Generic;
using MonoTouch.UIKit;
using MonoTouch.Dialog;
using MonoTouch.Foundation;
using MonoTouch.EventKit;

namespace Calendars.Screens.EventList
{
	public class EventListController : DialogViewController
	{
		// our roote element for MonoTouch.Dialog
		protected RootElement itemListRoot = new RootElement ( "Calendar/Reminder Items" );

		protected EKCalendarItem[] events;
		protected EKEntityType eventType;

		public EventListController ( EKCalendarItem[] events, EKEntityType eventType )
			: base ( UITableViewStyle.Plain, null, true)
		{
			this.events = events;
			this.eventType = eventType;

			// add elements to the dialog root for each item
			itemListRoot.Add (
				new Section ( ) { 
				from items in this.events
					select ( Element ) new StringElement ( items.Title )
				}
			);
			// set our element root
			this.InvokeOnMainThread ( () => { this.Root = itemListRoot; } ); 
		}
	}
}

