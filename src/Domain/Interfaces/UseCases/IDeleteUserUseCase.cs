namespace Domain.Interfaces.UseCases
{
	public interface IDeleteUserUseCase
	{
		Task Execute(string identification);
	}
}

