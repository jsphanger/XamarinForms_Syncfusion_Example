using System;
using System.Collections.Generic;
using Syncfusion.SfSchedule.XForms;

using Xamarin.Forms;

namespace SynchFusionExample
{
    public partial class EventInformation : ContentPage
    {
        public EventInformation(ScheduleAppointment apt)
        {
            InitializeComponent();

            //get the event information by id and display in the view
            LabelEventTitle.Text = "Subject: " + apt.Subject;
            LabelEventStartTime.Text = "Appointment Start: " + apt.StartTime.ToLocalTime().ToString();
            LabelEventEndTime.Text = "Appointment End: " + apt.EndTime.ToLocalTime().ToString();

        }

        public async void ButtonDismiss_Clicked(object sender, EventArgs e){
            await Navigation.PopModalAsync();
        }
    }
}
