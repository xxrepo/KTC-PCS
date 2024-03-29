using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace EVOFramework.Windows.Forms
{
	/// <summary>
	/// Summary description for Calendar.
	/// </summary>
	internal  class Calendar : System.Windows.Forms.Form
	{
		
		private System.Windows.Forms.MonthCalendar monthCalendar2;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private DateTime m_dtSelectDate;
		private bool m_IsSelect; // flag to check select date
		public DateTime GetDate{
			get{
				return m_dtSelectDate;
			}
		}
		public bool IsSelect{
			get{
				return m_IsSelect;
			}
			set{
				m_IsSelect = value;
			}
		}

		public DateTime Date{
			get{
				return m_dtSelectDate;
			}
			set{
				m_dtSelectDate = value;
			}
		}
		public delegate void MyHandler();
		public event MyHandler dHandle;

		public Calendar()
		{
			
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			
			
			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}
		public Calendar(DateTime dtDate){
			InitializeComponent();
			this.monthCalendar2.SetDate(dtDate);
			
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.monthCalendar2 = new System.Windows.Forms.MonthCalendar();
			this.SuspendLayout();
			// 
			// monthCalendar2
			// 
			this.monthCalendar2.BackColor = System.Drawing.Color.White;
			this.monthCalendar2.ForeColor = System.Drawing.Color.Navy;
			this.monthCalendar2.Location = new System.Drawing.Point(0, 0);
			this.monthCalendar2.Name = "monthCalendar2";
			this.monthCalendar2.TabIndex = 0;
			this.monthCalendar2.TitleBackColor = System.Drawing.Color.SteelBlue;
			this.monthCalendar2.TitleForeColor = System.Drawing.Color.White;
			this.monthCalendar2.TrailingForeColor = System.Drawing.Color.LightGray;
			this.monthCalendar2.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar2_DateSelected);
            this.monthCalendar2.DateChanged += new DateRangeEventHandler(monthCalendar2_DateChanged);
            // 
			// Calendar
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(192, 155);
			this.Controls.Add(this.monthCalendar2);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "Calendar";
			this.ShowInTaskbar = false;
			this.Text = "Calendar";
			this.TopMost = true;
			this.Load += new System.EventHandler(this.Calendar_Load);
			this.Activated += new System.EventHandler(this.Calendar_Activated);
			this.Deactivate += new System.EventHandler(this.Calendar_Deactivate);
			this.ResumeLayout(false);

		}

       
		#endregion



		private void Calendar_Load(object sender, System.EventArgs e) {
			m_IsSelect = false;
		}


		private void monthCalendar2_DateSelected(object sender, System.Windows.Forms.DateRangeEventArgs e) {
			this.m_IsSelect = true;
			m_dtSelectDate =  e.Start.Date;
			dHandle();
			this.Hide();
		}

        void monthCalendar2_DateChanged(object sender, DateRangeEventArgs e)
        {
            monthCalendar2.SelectionEnd = e.Start;

            //throw new NotImplementedException();
        }

		private void Calendar_Deactivate(object sender, System.EventArgs e) {
			if (m_IsSelect != true) {
				dHandle();
				this.Hide();
			}

		}

		private void Calendar_Activated(object sender, System.EventArgs e) {
			this.monthCalendar2.SetDate(m_dtSelectDate);
		}
	}
}
