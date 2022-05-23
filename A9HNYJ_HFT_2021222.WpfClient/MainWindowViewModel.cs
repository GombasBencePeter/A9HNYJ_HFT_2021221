using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using A9HNYJ_HFT_2021221.Models;
using A9HNYJ_HFT_2021222.RestClient;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;

namespace A9HNYJ_HFT_2021222.WpfClient
{

    class MainWindowViewModel :ObservableRecipient
    {

        public Book selectedBook;

        public Author selectedAuthor;

        public Publisher selectedPublisher;

        public Book SelectedBook
        {
            get => selectedBook;
            set
            {
                SetProperty(ref selectedBook, value);
                (DeleteBook as RelayCommand).NotifyCanExecuteChanged();

            }
        }
        public Author SelectedAuthor
        {
            get => selectedAuthor;
            set
            {
                SetProperty(ref selectedAuthor, value);
                (DeleteAuthor as RelayCommand).NotifyCanExecuteChanged();
                (ModAuthor as RelayCommand).NotifyCanExecuteChanged();

            }
        }
        public Publisher SelectedPublisher
        {
            get => selectedPublisher;
            set
            {
                SetProperty(ref selectedPublisher, value);
                (DeletePublisher as RelayCommand).NotifyCanExecuteChanged();

            }
        }
        public RestCollection<Book> Books { get; set; }
        public RestCollection<Author> Authors { get; set; }
        public RestCollection<Publisher> Publishers { get; set; }

        public UILogic logic;

        public ICommand CreateBook { get; set; }
        public ICommand CreateAuthor { get; set; }
        public ICommand CreatePublisher { get; set; }
        public ICommand ModPublisher { get; set; }
        public ICommand ModAuthor { get; set; }
        public ICommand ModBook { get; set; }
        public ICommand DeletePublisher { get; set; }
        public ICommand DeleteAuthor { get; set; }
        public ICommand DeleteBook { get; set; }
        public ICommand AddAuthor { get; set; }
        public ICommand AddPublisher { get; set; }
        public ICommand AddBook { get; set; }

        public MainWindowViewModel()
        {
            selectedAuthor = null;
            selectedBook = null;
            selectedPublisher = null;
            Books = new RestCollection<Book>("http://localhost:37921/admin/", "Book");
            Authors = new RestCollection<Author>("http://localhost:37921/admin/", "Author");
            Publishers = new RestCollection<Publisher>("http://localhost:37921/admin/", "Publisher");
            logic = new UILogic(Books, Authors, Publishers);

            DeletePublisher = new RelayCommand(
                () => Publishers.Delete(SelectedPublisher.PublisherID),
                () => SelectedPublisher != null
            );

            DeleteAuthor = new RelayCommand(
                 () => Authors.Delete(SelectedAuthor.AuthorKey),
                 () => SelectedAuthor != null
             );

            DeleteBook = new RelayCommand(
                 () => Books.Delete(SelectedBook.BookID),
                 () => SelectedBook != null
             );

            AddAuthor = new RelayCommand(
                () => logic.AddAuthor()
                );
            ModAuthor = new RelayCommand(
                () => logic.ModifyAuthor(SelectedAuthor),
                () => selectedAuthor != null
                ); ;
        }
    }
}
