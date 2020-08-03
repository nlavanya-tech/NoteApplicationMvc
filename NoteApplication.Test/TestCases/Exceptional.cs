using Moq;
using NoteApplication.BusinessLogics.Interface;
using NoteApplication.BusinessLogics.Services;
using NoteApplication.BusinessLogics.Services.Repository;
using NoteApplication.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace NoteApplication.Test.TestCases
{
 public class Exceptional
    {
        private INoteService _services;
        public readonly Mock<INoteRepository> service = new Mock<INoteRepository>();
        static Exceptional()
        {
            if (!File.Exists("../../../../output_exception_revised.txt"))
                try
                {
                    File.Create("../../../../output_exception_revised.txt").Dispose();
                }
                catch (Exception)
                {

                }
            else
            {
                File.Delete("../../../../output_exception_revised.txt");
                File.Create("../../../../output_exception_revised.txt").Dispose();
            }
        }
        public Exceptional()
        {
            _services = new NoteService(service.Object);
        }
        [Fact]
        public async Task<bool> Testfor_ValidateNotesId()
        {
            bool finalvalue = false;

            //Assigning values
            var notes = new Notes()
            {
                Id = 36,
                Title = "update",
                Author = "note",
                Description = "Note applicaction",
                Status = "done"
            };

            //setup
            service.Setup(repo => repo.CreateAsync(notes)).ReturnsAsync(notes);
            var result = await _services.CreateAsync(notes);
            if (result.Id >= 35 && result.Id <= 350000)
            {
                finalvalue = true;
            }
            else
                finalvalue = false;

            //finalresult displaying in text file
            File.AppendAllText("../../../../output_exception_revised.txt", "Testfor_ValidateNotesId=" + finalvalue + "\n");

            return finalvalue;
        }

    }
}
