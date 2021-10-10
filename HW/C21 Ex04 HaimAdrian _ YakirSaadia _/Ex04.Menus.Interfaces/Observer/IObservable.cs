namespace Ex04.Menus.Interfaces.Observer
{
	public interface IObservable<T>
	{
		void AddListener(IObserver<T> i_Listener);

		void RemoveListener(IObserver<T> i_Listener);

		void NotifyObservers(T i_Subject);
	}
}
