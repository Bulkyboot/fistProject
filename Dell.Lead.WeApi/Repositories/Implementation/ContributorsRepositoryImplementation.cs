using Dell.Lead.WeApi.Models;
using Dell.Lead.WeApi.Models.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Dell.Lead.WeApi.Repositories.Implementation
{
    public class ContributorsRepositoryImplementation : IContributorsRepository
    {
        private readonly SqlServerContext _context;

        public ContributorsRepositoryImplementation(SqlServerContext context)
        {
            _context = context;
        }
        public Contributors Create(Contributors contributors)
        {
            _context.Contributors.Add(contributors);
            _context.SaveChanges();

            return contributors;
        }

        public void Delete(long cpf)
        {
            var result = _context.Contributors.SingleOrDefault(e => e.Cpf.Equals(cpf));
            if (result != null)
            {
                try
                {
                    _context.Addresses.Remove(result.Address);
                    _context.Contributors.Remove(result);
                    _context.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public List<Contributors> FindAll()
        {
            return _context.Contributors.Include(a => a.Address).OrderBy(a => a.Name).ToList();
        }

        public Contributors FindByCpf(long cpf)
        {
            return _context.Contributors.Include(a => a.Address).Where(e => e.Cpf.Equals(cpf)).FirstOrDefault();
        }
        public bool IsCpf(long cpf)
        {
            string isCpf = Convert.ToString(cpf);

            int[] multiplierFirstDigit = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplierSecondDigit = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf;
            string digit;
            int sum;
            int rest;

            if (isCpf.Length != 11)
            {
                return false;
            }

            tempCpf = isCpf.Substring(0, 9);
            sum = 0;

            for (int i = 0; i < 9; i++)
            {
                sum += int.Parse(tempCpf[i].ToString()) * multiplierFirstDigit[i];
            }

            rest = sum % 11;

            if (rest < 2)
            {
                rest = 0;
            }
            else
            {
                rest = 11 - rest;
            }

            digit = rest.ToString();
            tempCpf = tempCpf + digit;
            sum = 0;
            for (int i = 0; i < 10; i++)
            {
                sum += int.Parse(tempCpf[i].ToString()) * multiplierSecondDigit[i];
            }

            rest = sum % 11;

            if (rest < 2)
            {
                rest = 0;
            }
            else
            {
                rest = 11 - rest;
            }

            digit = digit + rest.ToString();

            return isCpf.EndsWith(digit);
        }
        public Contributors Update(Contributors contributors)
        {
            if (Exists(contributors.Cpf))
            {
                var result = _context.Contributors.Include(a => a.Address).Where(e => e.Cpf.Equals(contributors.Cpf)).FirstOrDefault();
                if (result != null)
                {
                    try
                    {
                        _context.Entry(result).CurrentValues.SetValues(contributors);
                        _context.Entry(result.Address).CurrentValues.SetValues(contributors.Address);
                        _context.SaveChanges();
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                    return result;
                }

            }
            return null;
        }

        public bool Exists(long cpf)
        {
            return _context.Contributors.Any(e => e.Cpf.Equals(cpf));
        }
    }
}