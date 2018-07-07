using System;

using Syncfusion.SfSchedule.XForms;
using Xamarin.Forms;

namespace SynchFusionExample
{
    public partial class SynchFusionExamplePage : ContentPage
    {
        ScheduleAppointmentCollection appointments { get; set; }
        //NonAccessibleBlocksCollection blackouts { get; set; }

        public SynchFusionExamplePage()
        {
            InitializeComponent();

            appointments = new ScheduleAppointmentCollection();

            SetSchedule();
            AddEvent();
        }

        public void SetSchedule(){
            //** NOTE: Look, we would love to use the blackout options the library has included
            //** however they will not allow for a blackout of specific day and time combos
            //** such as friday from 5 - 8 pm.. etc

            //Store the black out time as UTC
            ScheduleItem blackout = new ScheduleItem()
            {
                Title = "Booked",
                StartDateTime = new DateTime(2017, 06, 22, 10, 00, 00).ToUniversalTime(),
                EndDateTime = new DateTime(2017, 06, 22, 12, 00, 00).ToUniversalTime()
            };

            //Read from the blackout time as local time
            appointments.Add(new ScheduleAppointment(){
                StartTime = blackout.StartDateTime.ToLocalTime(),
                EndTime = blackout.EndDateTime.ToLocalTime(),
                Subject = blackout.Title,
                Color = Color.Black
            });

            Schedule.DataSource = appointments;

            Schedule.MonthInlineAppointmentTapped += async (object sender, MonthInlineAppointmentTappedEventArgs args) => {
                //display a pop up with the event details!
                var appointment = (args.Appointment as ScheduleAppointment);
                if (appointment.Color != Color.Black)
                {
                    await Navigation.PushModalAsync(new EventInformation(appointment));
                }
            };

            Schedule.CellTapped += async (object sender, CellTappedEventArgs args) => {
                if(Schedule.ScheduleView == ScheduleView.WeekView){
					//display a pop up with the event details!
					var appointment = (args.Appointment as ScheduleAppointment);
                    if (appointment.Color != Color.Black)
                    {
                        await Navigation.PushModalAsync(new EventInformation(appointment));
                    }
                }
            };
        }

        public void AddEvent(){

            //Adding schedule appointment in schedule appointment collection 
			appointments.Add(new ScheduleAppointment()
			{
				StartTime = new DateTime(2017, 06, 21, 10, 0, 0),
				EndTime = new DateTime(2017, 06, 21, 12, 0, 0),
				Subject = "Meeting",
				Location = "Hutchison road", 
                Color = Color.LightGreen
			});

            //Adding schedule appointment collection to DataSource of SfSchedule
            Schedule.DataSource = appointments;
		}

        public void ButtonMonthView_Clicked (object sender, EventArgs e){
            Schedule.ScheduleView = ScheduleView.MonthView;
        }

		public void ButtonWeekView_Clicked(object sender, EventArgs e)
		{
            Schedule.ScheduleView = ScheduleView.WeekView;
		}
    }
}
