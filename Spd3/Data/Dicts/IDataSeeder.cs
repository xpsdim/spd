namespace Spd3.Data.Dicts
{
	public interface IDataSeeder<T>  where T : class
	{
		T[] GetEntities { get; }
	}
}
