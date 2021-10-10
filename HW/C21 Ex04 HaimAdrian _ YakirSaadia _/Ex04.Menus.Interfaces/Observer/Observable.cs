using System.Collections.Generic;
using Ex04.Menus.Interfaces.Collections;

namespace Ex04.Menus.Interfaces.Observer
{
	public class Observable<T> : IObservable<T>
	{
		// Lazy initialization, hence it is not readonly.
		private ICollection<IObserver<T>> m_Listeners;

		public static Observable<T> operator +(Observable<T> i_Observable, IObserver<T> i_Observer)
		{
			i_Observable.AddListener(i_Observer);
			return i_Observable;
		}

		public static Observable<T> operator -(Observable<T> i_Observable, IObserver<T> i_Observer)
		{
			i_Observable.RemoveListener(i_Observer);
			return i_Observable;
		}

		public void AddListener(IObserver<T> i_Listener)
		{
			if (m_Listeners == null)
			{
				m_Listeners = new HashSet<IObserver<T>>();
			}

			m_Listeners.Add(i_Listener);
		}

		public void RemoveListener(IObserver<T> i_Listener)
		{
			if (m_Listeners != null)
			{
				m_Listeners.Remove(i_Listener);
			}
		}

		public void NotifyObservers(T i_Subject)
		{
			if (m_Listeners != null)
			{
				foreach (IObserver<T> currentListener in m_Listeners)
				{
					currentListener.Update(i_Subject);
				}
			}
		}
	}
}
