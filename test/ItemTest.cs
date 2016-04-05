using System.Collections.Generic;
using firstaspnet.Data.Entities;
using firstaspnet.Test.EntityMock;
using firtaspnet.Controllers;
using Microsoft.AspNet.Http.Internal;
using Microsoft.AspNet.Mvc;
using Microsoft.Extensions.Primitives;
using Xunit;

namespace firstaspnet.Test
{
    public class ItemTest
    {
        [Fact]
        public void WhenIfNotHaveFileItemThenShowError()
        {
            /*
               For month i generate a file with data, the my finanzas, then for save need have a file.
            */
            var controller = new ItemController(new ItemContextMock());
            FormCollection collection = null;
            var result = controller.Save(collection) as ViewResult;
            
           Assert.Equal("Error", result.ViewName);
           
        }
        
        [Fact]
        public void WhenHaveFileItemThenSave()
        {
            /*
               if have then save Data.
            */
            var controller = new ItemController(new ItemContextMock());
            IDictionary<string, StringValues> dictionary = 
            new Dictionary<string, StringValues>();
            
            dictionary.Add("Name", "val");
            FormCollection collection = new FormCollection(dictionary);
            var result = controller.Save(collection) as ViewResult;
            
            Assert.Equal("Index", result.ViewName);
        }
        
        [Fact]
        public void WhenSetDataWrongThenNotSave()
        {
            /*Sent data to save, but this not is a number, then error*/
            var controller = new ItemController(new ItemContextMock());
            IDictionary<string, StringValues> dictionary = 
            new Dictionary<string, StringValues>();
            
            dictionary.Add("Debt", "asdf");
            FormCollection collection = new FormCollection(dictionary);
            var result = controller.Save(collection) as ViewResult;
            
            Assert.Equal("Index", result.ViewName);
        }
        
        
        
    }
}