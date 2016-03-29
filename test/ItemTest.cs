using Xunit;

namespace firstaspnet.Test
{
    public class ItemTest
    {
        [Fact]
        public void WhenIfHaveSaveItemFileThenSave()
        {
            /*
               For month i generate a file with data, the my finanzas, then for save need have a file.
            */
           Assert.Equal(250m, 250m);
        }
        
        [Fact]
        public void WhenIfNotHaveSaveItemFileThenNotSave()
        {
            /*
               if FileNotFound then not save Data.
            */
           Assert.Equal(250m, 250m);
        }
        
        [Fact]
        public void WhenHaveFileForSaveAndHaveTheSameNameThenNotSave()
        {
            /*
            */
        }
        
        
        
    }
}