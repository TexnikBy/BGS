using Ardalis.Specification;

namespace BGS.SharedKernel;

public interface IRepository<T> : IRepositoryBase<T> where T : EntityBase { }