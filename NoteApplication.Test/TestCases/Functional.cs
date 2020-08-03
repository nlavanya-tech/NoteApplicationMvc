using Moq;
using NoteApplication.BusinessLogics.Interface;
using NoteApplication.BusinessLogics.Services;
using NoteApplication.BusinessLogics.Services.Repository;
using NoteApplication.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xunit;

namespace NoteApplication.Test.TestCases
{
    public class Functional
    {
        private INoteService _services;
        public readonly Mock<INoteRepository> service = new Mock<INoteRepository>();
        static Functional()
        {
            if (!File.Exists("../../../../output_revised.txt"))
                try
                {
                    File.Create("../../../../output_revised.txt").Dispose();
                }
                catch (Exception)
                {

                }
            else
            {
                File.Delete("../../../../output_revised.txt");
                File.Create("../../../../output_revised.txt").Dispose();
            }
        }
        public Functional()
        {
            _services = new NoteService(service.Object);
        }
        Random random = new Random();
        [Fact]
        public async void Test_GetAllNotesAndStatus()
        {
            //assigning value
            bool finalresult = false;

            //setup
            service.Setup(repo => repo.ReadAsync());
            var result = await _services.ReadAsync();
            if (result != null) { finalresult = true; }

            //finalresult displaying in text file
            File.AppendAllText("../../../../output_revised.txt", "Test_GetAllNotesAndStatus=" + finalresult + "\n");

            Assert.NotNull(result);

        }
        [Fact]
        public async void Test_CreateNewNotes()
        {
            //Assigning values 
            var notes = new Notes()
            {
                Id = 1,
                Title = "d",
                Author = "d",
                Description = "d",
                Status = "done"
            };
            bool final = false;

            //setup
           service.Setup(repo => repo.CreateAsync(notes)).ReturnsAsync(notes);
            var result = await _services.CreateAsync(notes);
            if (notes == result)
                final = true;


            //finalresult displaying in text file
            File.AppendAllText("../../../../output_revised.txt", "Test_CreateNewNotes=" + final + "\n");
            Assert.Equal(notes, result);
        }
        [Fact]
        public async void Test_UpdatedNotes()
        {
            //assigning values
            var notes = new Notes()
            {
                Id = 123,
                Title = "update",
                Author = "note",
                Description = "Note applicaction",
                Status = "done"
            };
            bool finalresult = false;

            //setup
            service.Setup(repo => repo.UpdateAsync(notes)).ReturnsAsync(notes);
            var result = await _services.UpdateAsync(notes);
            if (notes == result) { finalresult = true; }


            //finalresult displaying in text file
            File.AppendAllText("../../../../output_revised.txt", "Test_UpdatedNotes=" + finalresult + "\n");
            Assert.Equal(notes, result);
        }
        [Fact]
        public async void Test_ValidateEmptyNotes()
        {
            //assigning values
            var notes = new Notes() { };
            bool finalresult = false;

            //setup
            service.Setup(repo => repo.UpdateAsync(notes)).ReturnsAsync(notes);
            var result = await _services.UpdateAsync(notes);
            if (result != null)
                finalresult = true;

            //finalresult displaying in text file
            File.AppendAllText("../../../../output_revised.txt", "Test_ValidateEmptyNotes=" + finalresult + "\n");
            Assert.NotNull(result);
        }
        [Fact]
        public async void Test_DeleteNotesList()
        {
            //asigning values
            var notes = new Notes()
            {
                Id = 44
            };
            bool finalresult = false;

            //setup
            service.Setup(repo => repo.DeleteAsync(notes)).ReturnsAsync(notes);
            var result = await _services.DeleteAsync(notes);
            if (result.Id == notes.Id)
                finalresult = true;

            //finalresult displaying in text file
            File.AppendAllText("../../../../output_revised.txt", "Test_DeleteNotesList=" + finalresult + "\n");
            Assert.Equal(notes.Id, result.Id);
        }
        [Fact]
        public async void Test_ValidateDeleteNoteNull()
        {
            //Assigning values
            var notes = new Notes() { };
            bool finalresult = false;

            //setup
            service.Setup(repo => repo.DeleteAsync(notes)).ReturnsAsync(notes);
            var result = await _services.DeleteAsync(notes);
            if (result != null)
            {
                finalresult = true;
            }
            //finalresult displaying in text file
            File.AppendAllText("../../../../output_revised.txt", "Test_ValidateDeleteNoteNull=" + finalresult + "\n");
            Assert.NotNull(result);
        }
    }
}
