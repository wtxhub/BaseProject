using DataLayer.Repository;
using Entity;
using System;
using System.Collections.Generic;

namespace ServiceLayer.Manager
{

	public interface ICompanyService
	{
		Company Create (Guid userId, Company data);
		Company Read (Guid userId, Guid id);
		Company Update (Guid userId, Company data);
		Company Delete (Guid userId, Company data);
		IEnumerable<Company> List (Guid userId);

		string Test ();

	}


	public class CompanyService : ICompanyService
	{

		public readonly ICompanyRepository _companyRepo;

		public CompanyService (ICompanyRepository companyRepo)
		{
			_companyRepo = companyRepo;
		}


		public Company Create (Guid userId, Company data)
		{
			throw new NotImplementedException();
		}

		public Company Read (Guid userId, Guid id)
		{
			throw new NotImplementedException();
		}

		public Company Update (Guid userId, Company data)
		{
			throw new NotImplementedException();
		}

		public Company Delete (Guid userId, Company data)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<Company> List (Guid userId)
		{
			throw new NotImplementedException();
		}


		public string Test ()
		{
			return _companyRepo.Test();
		}

	}
}
