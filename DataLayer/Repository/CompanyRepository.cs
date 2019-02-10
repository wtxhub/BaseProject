using DataLayer.DataContext;
using Entity;
using System;
using System.Collections.Generic;

namespace DataLayer.Repository
{

	public interface ICompanyRepository
	{
		Company Create (Company data);
		Company Read (Guid id);
		Company Update (Company data);
		Company Delete (Company data);
		IEnumerable<Company> List ();

		string Test ();
	}


	public class CompanyRepository : ICompanyRepository
	{

		public readonly IUnitOfWork _unitOfWork;

		public CompanyRepository (IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}


		public Company Create (Company data)
		{
			throw new NotImplementedException();
		}

		public Company Read (Guid id)
		{
			throw new NotImplementedException();
		}

		public Company Update (Company data)
		{
			throw new NotImplementedException();
		}

		public Company Delete (Company data)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<Company> List ()
		{
			throw new NotImplementedException();
		}

		public string Test ()
		{
			return "this is just a really simple test";
		}

	}
}
