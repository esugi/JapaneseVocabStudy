using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409


namespace VocabStudy_Basic
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        VocabList vlist;
        public MainPage()
        {
            this.InitializeComponent();
            vlist = new VocabList();
        }

        private void Next_Click(Object sender, RoutedEventArgs e)
        {
            tbWord.Text = vlist.getNextRnd();
        }

        private class VocabList
        {
            int listSize;
            String currentWord;
            ArrayList vocabList;
            Random rnd;

            public VocabList()
            {
                vocabList = new ArrayList();
                listSize = 0;
                rnd = new Random();
                loadVocabList();
            }
            private void loadVocabList()
            {
                System.IO.StreamReader file = new System.IO.StreamReader(@"vocablist.txt");

                while((currentWord = file.ReadLine()) != null)
                {
                    vocabList.Add(currentWord);
                    listSize++;
                }

                file.Close();

            }
            public String getNextRnd()
            {
                int rndIdx = rnd.Next(listSize);
                return vocabList[rndIdx].ToString();
            }
            public int getSize()
            {
                return listSize;
            }
        }
        
    }
}
