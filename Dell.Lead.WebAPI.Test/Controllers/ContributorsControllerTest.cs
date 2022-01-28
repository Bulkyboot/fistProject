using Dell.Lead.WeApi.Business;
using Dell.Lead.WeApi.Controllers;
using Dell.Lead.WeApi.Data.VO;
using Dell.Lead.WeApi.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace Dell.Lead.WeApi.Test.Controllers
{
    public class EmployeeControllerTest
    {

        private readonly Mock<IContributorsBusiness> _mockContributorsBusiness;

        public EmployeeControllerTest()
        {
            _mockContributorsBusiness = new Mock<IContributorsBusiness>();

        }

        private ContributorsController contributorsControllers(Mock<IContributorsBusiness> mockContributorsBusiness)
        {
            return new ContributorsController(mockContributorsBusiness.Object);

        }

        [Fact]
        public void FindAll()
        {
            List<ContributorsVO> contributors = new List<ContributorsVO>()
            {
                new ContributorsVO()
                {
                    Name = "Ruan Bezerra",
                    Cpf = 079510704300,
                    DateOfBirth = Convert.ToDateTime("2003-02-13T00:00:00"),
                    Gender = "Heterossexual",
                    Cellfone = 85985091635,
                    Address = new AddressVO()
                    {
                        Street = "Rua Jaime Vasconcelos",
                        Number = 170,
                        District = "Mucuripe",
                        City = "Fortaleza",
                        State = "Ceara",
                        Cep = 60165260
                    }
                },
                new ContributorsVO()
                {
                    Name = "Lia Abda",
                    Cpf = 08141040306,
                    DateOfBirth = Convert.ToDateTime("2004-04-16T00:00:00"),
                    Gender = "Heterossexual",
                    Cellfone = 85987402451,
                    Address = new AddressVO()
                    {
                        Street = "Rua 15 de Novembro",
                        Number = 400,
                        District = "Montese",
                        City = "Fortaleza",
                        State = "Ceara",
                        Cep = 40415165
                    }
                }
            };

            _mockContributorsBusiness.Setup(x => x.FindAll()).Returns(contributors);

            var contributorsController = contributorsControllers(_mockContributorsBusiness);
            ActionResult<List<ContributorsVO>> response = contributorsController.FindAll();
            OkObjectResult result = (OkObjectResult)response.Result;

            Assert.Equal(200, result.StatusCode);

        }

        [Fact]
        public void FindByCpf()
        {
            var contributorsVO = new ContributorsVO()
            {
                Name = "Ruan Bezerra",
                Cpf = 07951070300,
                DateOfBirth = Convert.ToDateTime("2004-04-16T00:00:00"),
                Gender = "Heterossexual",
                Cellfone = 85987402451,
                Address = new AddressVO()
                {
                    Street = "Rua Jaime Vasconcelos",
                    Number = 170,
                    District = "Montese",
                    City = "Fortaleza",
                    State = "Ceara",
                    Cep = 40415165

                }

            };

            _mockContributorsBusiness.Setup(x => x.FindByCpf(It.Is<long>(item => item.Equals(contributorsVO.Cpf)))).Returns(contributorsVO);

            var contributorsController = contributorsControllers(_mockContributorsBusiness);

            ActionResult<ContributorsVO> response = contributorsController.FindByCpf(contributorsVO.Cpf);
            OkObjectResult result = (OkObjectResult)response.Result;

            Assert.Equal(200, result.StatusCode);
            Assert.Equal(contributorsVO, result.Value);
        }
    }
}