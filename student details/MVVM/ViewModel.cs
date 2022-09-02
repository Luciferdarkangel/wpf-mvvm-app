using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace student_details.MVVM
	 
{
    
    
		public class ViewModel : INotifyPropertyChanged
		{
			public event PropertyChangedEventHandler? PropertyChanged;

			public void RaisePropertyChanged(string propertyName)
			{
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
			}

			public bool SetProperty<T>(ref T field, T value, string propertyName)
			{
				if (!EqualityComparer<T>.Default.Equals(field, value))
				{
					field = value;
					RaisePropertyChanged(propertyName);
					return true;
				}
				return false;
			}
		}
	
}
