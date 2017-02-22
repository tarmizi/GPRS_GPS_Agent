using System.Collections.Generic;
using System.Configuration;
using System.Linq;



namespace GPSAgent.Data
{
	public class GPSTrackers : ConfigurationElementCollection, IEnumerable<GPSTracker>
	{
		public GPSTracker this[int index]
		{
			get
			{
				return base.BaseGet(index) as GPSTracker;
			}
			set
			{
				if (base.BaseGet(index) != null)
				{
					base.BaseRemoveAt(index);
				}
				base.BaseAdd(index, value);
			}
		}

		public bool Contains(GPSTracker element)
		{
			return this.Any(o => o.Model.Equals(element.Model));
		}
		public int IndexOf(GPSTracker element)
		{
			for (int i = 0; i < this.Count; i++)
			{
				if (this[i].Equals(element))
					return i;
			}

			return -1;
		}
		public void Add(GPSTracker element)
		{
			base.BaseAdd(element, true);
		}
		public void Clear()
		{
			base.BaseClear();
		}

		protected override System.Configuration.ConfigurationElement CreateNewElement()
		{
			return new GPSTracker();
		}
		protected override object GetElementKey(System.Configuration.ConfigurationElement element)
		{
			return (element as GPSTracker).Model;
		}

		public new IEnumerator<GPSTracker> GetEnumerator()
		{
			int count = base.Count;

			for (int i = 0; i < count; i++)
			{
				yield return base.BaseGet(i) as GPSTracker;
			}
		}
	}
}
