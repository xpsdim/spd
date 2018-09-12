namespace Spd.Data.Dicts
{
	public interface IDataSeeder<T>  where T : class
	{
		T[] GetEntities { get; }
	}
}
