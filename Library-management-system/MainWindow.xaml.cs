using DataLayer.context;
using DataLayer.Models;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ViewModels.BookView;
using ViewModels.MemberView;
using LibraryUtility;
using System;

namespace Library_management_system
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
        }

        public void ChangeCopyType(int copyNumber, TypeN type)
        {
            using (AccessData data = new AccessData())
            {
                var item = data.CopyRipository.GetCopyById(copyNumber);

                Copy copy1 = new Copy()
                {
                    BookNumber = item.BookNumber,
                    CopyNumber = item.CopyNumber,
                    Price = item.Price,
                    SequenceNumber = item.SequenceNumber,
                    Type = (int)type,
                };
                data.CopyRipository.UpdateCopy(copy1);
                data.Save();

            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            btnBorrowCopy.IsEnabled = false;
            dpReturnDate.SelectedDate = DateTime.Now;
            dpBorrowDate.DisplayDateStart = DateTime.Now;
            dpBorrowDate.SelectedDate = DateTime.Now;
            dpDueDate.DisplayDateStart = DateTime.Now;
            dpReservationDate.DisplayDateStart = DateTime.Now;
            dpReservationDate.SelectedDate = DateTime.Now;
            BindGridMember();
            BindGridBook();
            BindGridCopy();
            Fontcheck();
        }

        // contole borders
        #region
        public void Fontcheck()
        {
            btnBook.FontSize = BookTab.Visibility == Visibility.Visible ? 25 : 18;
            btnMember.FontSize = MemberTab.Visibility == Visibility.Visible ? 25 : 18;
            btnBorrow.FontSize = BorrowTab.Visibility == Visibility.Visible ? 25 : 18;
            btnReturn.FontSize = ReturnTab.Visibility == Visibility.Visible ? 25 : 18;
            btnReserve.FontSize = ReserveTab.Visibility == Visibility.Visible ? 25 : 18;

        }

        private void btnBook_Click(object sender, RoutedEventArgs e)
        {
            BookTab.Visibility = Visibility.Visible;
            MemberTab.Visibility = Visibility.Collapsed;
            BorrowTab.Visibility = Visibility.Collapsed;
            ReturnTab.Visibility = Visibility.Collapsed;
            ReserveTab.Visibility = Visibility.Collapsed;
            Fontcheck();
        }

        private void btnMember_Click(object sender, RoutedEventArgs e)
        {
            BookTab.Visibility = Visibility.Collapsed;
            MemberTab.Visibility = Visibility.Visible;
            BorrowTab.Visibility = Visibility.Collapsed;
            ReturnTab.Visibility = Visibility.Collapsed;
            ReserveTab.Visibility = Visibility.Collapsed;
            Fontcheck();
        }

        private void btnBorrow_Click(object sender, RoutedEventArgs e)
        {
            BookTab.Visibility = Visibility.Collapsed;
            MemberTab.Visibility = Visibility.Collapsed;
            BorrowTab.Visibility = Visibility.Visible;
            ReturnTab.Visibility = Visibility.Collapsed;
            ReserveTab.Visibility = Visibility.Collapsed;
            Fontcheck();
        }

        private void btnReturn_Click(object sender, RoutedEventArgs e)
        {
            BookTab.Visibility = Visibility.Collapsed;
            MemberTab.Visibility = Visibility.Collapsed;
            BorrowTab.Visibility = Visibility.Collapsed;
            ReturnTab.Visibility = Visibility.Visible;
            ReserveTab.Visibility = Visibility.Collapsed;
            Fontcheck();
        }

        private void btnReserve_Click(object sender, RoutedEventArgs e)
        {
            BookTab.Visibility = Visibility.Collapsed;
            MemberTab.Visibility = Visibility.Collapsed;
            BorrowTab.Visibility = Visibility.Collapsed;
            ReturnTab.Visibility = Visibility.Collapsed;
            ReserveTab.Visibility = Visibility.Visible;
            Fontcheck();
        }

        #endregion


        // control books 
        #region
        public void BindGridBook()
        {
            using (AccessData Data = new AccessData())
            {
                ObservableCollection<BookViewModel1> books = new ObservableCollection<BookViewModel1>(Data.BookRipository.GetBookModel1());
                dgBook.ItemsSource = books;
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtTitle.Text) && !string.IsNullOrEmpty(txtAuthor.Text) && !string.IsNullOrEmpty(txtPublisher.Text) && txtnumberBook.Text == "---")
            {
                using (AccessData Data = new AccessData())
                {
                    Book book = new Book()
                    {
                        Title = txtTitle.Text,
                        Author = txtAuthor.Text,
                        Publisher = txtPublisher.Text,
                    };
                    Data.BookRipository.InsertBook(book);
                    Data.Save();
                    BindGridBook();
                }
            }
            else
            {
                MessageBox.Show("Error", "error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Are you sure ?", "Ohh!", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                if (dgBook.SelectedIndex >= 0)
                {
                    using (AccessData Data = new AccessData())
                    {
                        var item = dgBook.SelectedItem as BookViewModel1;
                        if (!Data.CopyRipository.GetCopyModel1().Any(x => x.BookNumber == item.BookNumber))
                        {
                            Data.BookRipository.DeleteBook(item.BookNumber);
                            Data.Save();
                            BindGridBook();
                        }
                        else
                        {
                            MessageBox.Show("Error", "error", MessageBoxButton.OK, MessageBoxImage.Error);
                        }

                    }
                }
                else
                {
                    MessageBox.Show("Error", "error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (txtnumberBook.Text != "---")
            {
                using (AccessData Data = new AccessData())
                {
                    Book book = new Book()
                    {
                        BookNumber = int.Parse(txtnumberBook.Text),
                        Title = txtTitle.Text,
                        Author = txtAuthor.Text,
                        Publisher = txtPublisher.Text,
                    };
                    Data.BookRipository.UpdateBook(book);
                    Data.Save();
                    BindGridBook();
                    btnCleanUp_Click(sender, e);
                }
            }
            else
            {
                MessageBox.Show("Error", "error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void dgBook_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (dgBook.SelectedIndex >= 0)
            {
                var item = dgBook.SelectedItem as BookViewModel1;
                txtTitle.Text = item.Title;
                txtAuthor.Text = item.Author;
                txtPublisher.Text = item.Publisher;
                txtnumberBook.Text = item.BookNumber.ToString();
            }
        }

        private void btnCleanUp_Click(object sender, RoutedEventArgs e)
        {
            txtTitle.Text = "";
            txtAuthor.Text = "";
            txtPublisher.Text = "";
            txtnumberBook.Text = "---";
            dgBook.SelectedIndex = -1;
        }

        #endregion


        // control copys
        #region
        public void BindGridCopy()
        {
            using (AccessData data = new AccessData())
            {
                ObservableCollection<CopyViewModel1> copies = new ObservableCollection<CopyViewModel1>(data.CopyRipository.GetCopyModel1());
                dgCopy.ItemsSource = copies;
            }
        }

        private void dgCopy_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (dgCopy.SelectedIndex >= 0)
            {
                var item = dgCopy.SelectedItem as CopyViewModel1;
                txtCopyNumber1.Text = item.CopyNumber.ToString();
                txtBooknumber2.Text = item.BookNumber.ToString();
                txtPrice.Text = item.Price.ToString();
                txtSequenceNumber.Text = item.SequenceNumber.ToString();
                cbType.SelectedIndex = (int)item.Type;
            }
        }

        private void btnAdd2_Click(object sender, RoutedEventArgs e)
        {
            string? s1 = txtPrice.Text;
            string? s2 = txtSequenceNumber.Text;
            if (double.TryParse(s1, out double P) && cbType.SelectedIndex >= 0 && int.TryParse(s2, out int S) && txtCopyNumber1.Text == "---")
            {
                using (AccessData data = new AccessData())
                {
                    if (data.BookRipository.GetBookModel1().Any(x => x.BookNumber.ToString() == txtBooknumber2.Text))
                    {
                        Copy copy = new Copy()
                        {
                            BookNumber = int.Parse(txtBooknumber2.Text),
                            Type = cbType.SelectedIndex,
                            Price = P,
                            SequenceNumber = S,
                        };
                        data.CopyRipository.InsertCopy(copy);
                        data.Save();
                        BindGridCopy();
                    }
                    else
                    {
                        MessageBox.Show("this Book number does not exist", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Error", "error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnDelete2_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Are you sure ?", "Ohh!", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                if (dgCopy.SelectedIndex >= 0)
                {
                    var item = dgCopy.SelectedItem as CopyViewModel1;
                    using (AccessData data = new AccessData())
                    {
                        data.CopyRipository.DeleteCopy(item.CopyNumber);
                        data.Save();
                        BindGridCopy();
                    }
                }
                else
                {
                    MessageBox.Show("Error", "error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void btnEdit2_Click(object sender, RoutedEventArgs e)
        {
            string? s1 = txtPrice.Text;
            string? s2 = txtSequenceNumber.Text;
            if (double.TryParse(s1, out double P) && cbType.SelectedIndex >= 0 && int.TryParse(s2, out int S))
            {
                using (AccessData data = new AccessData())
                {
                    if (data.BookRipository.GetBookModel1().Any(x => x.BookNumber.ToString() == txtBooknumber2.Text))
                    {
                        Copy copy = new Copy()
                        {
                            CopyNumber = int.Parse(txtCopyNumber1.Text),
                            BookNumber = int.Parse(txtBooknumber2.Text),
                            Type = cbType.SelectedIndex,
                            Price = P,
                            SequenceNumber = S,
                        };
                        data.CopyRipository.UpdateCopy(copy);
                        data.Save();
                        BindGridCopy();
                    }
                    else
                    {
                        MessageBox.Show("this Book number does not exist", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Error", "error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnCleanUp2_Click(object sender, RoutedEventArgs e)
        {
            txtCopyNumber1.Text = "---";
            txtBooknumber2.Text = "";
            txtPrice.Text = "";
            txtSequenceNumber.Text = "";
            cbType.SelectedIndex = -1;
            dgCopy.SelectedIndex = -1;
        }
        #endregion


        // control memebers
        #region
        public void BindGridMember()
        {
            using (AccessData Data = new AccessData())
            {
                ObservableCollection<MemberViewModel1> members = new ObservableCollection<MemberViewModel1>(Data.MemberRipository.GetMemberModel1());
                dgMember.ItemsSource = members;
            }
        }

        private void btnAdd3_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtAddress.Text) && !string.IsNullOrEmpty(txtName.Text) && !string.IsNullOrEmpty(txtEmail.Text)
                && !string.IsNullOrEmpty(txtTelephone.Text) && txtMemberNumber1.Text == "---" && cbGender.SelectedIndex >= 0)
            {
                using (AccessData data = new AccessData())
                {
                    Member member = new Member()
                    {
                        Name = txtName.Text,
                        Email = txtEmail.Text,
                        Telephone = txtTelephone.Text,
                        Addess = txtAddress.Text,
                        Sex = cbGender.SelectedIndex == 0 ? false : true,
                    };
                    data.MemberRipository.InsertMember(member);
                    data.Save();
                    BindGridMember();
                }
            }
            else
            {
                MessageBox.Show("Error", "error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnDelete3_Click(object sender, RoutedEventArgs e)
        {
            if (dgMember.SelectedIndex >= 0)
            {
                var item = dgMember.SelectedItem as MemberViewModel1;
                using (AccessData data = new AccessData())
                {
                    bool ali = data.MemberRipository.DeleteMember(item.MemberNumber);
                    data.Save();
                    BindGridMember();
                }
            }
        }

        private void btnEdit3_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtAddress.Text) && !string.IsNullOrEmpty(txtName.Text) && !string.IsNullOrEmpty(txtEmail.Text)
               && !string.IsNullOrEmpty(txtTelephone.Text) && txtMemberNumber1.Text != "---" && cbGender.SelectedIndex >= 0)
            {
                using (AccessData data = new AccessData())
                {
                    Member member = new Member()
                    {
                        MemberNumber = int.Parse(txtMemberNumber1.Text),
                        Name = txtName.Text,
                        Email = txtEmail.Text,
                        Telephone = txtTelephone.Text,
                        Addess = txtAddress.Text,
                        Sex = cbGender.SelectedIndex == 0 ? false : true,
                    };
                    data.MemberRipository.UpdateMember(member);
                    data.Save();
                    BindGridMember();
                }
            }
            else
            {
                MessageBox.Show("Error", "error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnCleanUp3_Click(object sender, RoutedEventArgs e)
        {
            txtAddress.Text = "";
            txtMemberNumber1.Text = string.Empty;
            txtName.Text = "";
            txtEmail.Text = "";
            txtTelephone.Text = "";
            cbGender.SelectedIndex = -1;
            dgMember.SelectedIndex = -1;
        }

        private void dgmMember_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (dgMember.SelectedIndex >= 0)
            {
                var item = dgMember.SelectedItem as MemberViewModel1;
                txtAddress.Text = item.Address;
                txtMemberNumber1.Text = item.MemberNumber.ToString();
                txtName.Text = item.Name;
                txtEmail.Text = item.Email;
                txtTelephone.Text = item.Telephone;
                cbGender.SelectedIndex = (int)item.Sex;
            }
        }

        #endregion


        // control borrow
        #region
        public void BindGridCirculated(int num)
        {
            using (AccessData data = new AccessData())
            {
                ObservableCollection<CirculatedViewModel1> circulateds = new ObservableCollection<CirculatedViewModel1>(data.CirculatedRipository.GetAllCirculatedWithMemberNumber(num));
                dgCirculated.ItemsSource = circulateds;
            }
        }

        private void btnMemberCheck_Click(object sender, RoutedEventArgs e)
        {
            using (AccessData data = new AccessData())
            {
                bool ex = true;
                //check input type
                string? S = txtMemberNumbercheck.Text;
                if (!int.TryParse(S, out int Num))
                {
                    MessageBox.Show("Error", "error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                //check member number and fill Data
                var item = data.MemberRipository.GetMemberModel2ById(Num, out ex);

                if (!ex)
                {
                    txtNameCheck.Text = item.Name;
                    txtTelephoneCheck.Text = item.Telephone;
                    BindGridCirculated(Num);
                }
                else
                {
                    MessageBox.Show("this Member Code does not exist !", "error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void btnCheckCopyCondition_Click(object sender, RoutedEventArgs e)
        {
            using (AccessData data = new AccessData())
            {
                //check input
                string? S = txtBorrowCopyCheck.Text;
                if (!int.TryParse(S, out int Num))
                {
                    MessageBox.Show("Error", "error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                var item = data.CopyRipository.GetCopyById(Num);
                // check condition
                if (item != null)
                {
                    MessageBox.Show($"Title :{data.BookRipository.GetBookById(item.BookNumber).Title} , SequenceNumber : {item.SequenceNumber} is {(TypeN)item.Type}",
                        "Oh", MessageBoxButton.OK, MessageBoxImage.Information);
                    if ((TypeN)item.Type == TypeN.Available)
                    {
                        btnBorrowCopy.IsEnabled = true;

                    }
                }
                else
                {
                    MessageBox.Show("This Copy does not exist ", "error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void btnBorrowCopy_Click(object sender, RoutedEventArgs e)
        {
            using (AccessData data = new AccessData())
            {
                if (dpBorrowDate.SelectedDate != null && dpDueDate.SelectedDate != null && (txtNameCheck != null || txtTelephoneCheck != null))
                {
                    Circulated circulated = new Circulated()
                    {
                        MemberNumber = int.Parse(txtMemberNumbercheck.Text),
                        CopyNumber = int.Parse(txtBorrowCopyCheck.Text),
                        BorrowDate = dpBorrowDate.SelectedDate.Value,
                        DueDate = dpDueDate.SelectedDate.Value,
                    };

                    data.CirculatedRipository.InsertCirculated(circulated);
                    data.Save();

                    ChangeCopyType(int.Parse(txtBorrowCopyCheck.Text), TypeN.Borrowed);
                    BindGridCopy();

                    // fill datagrid
                    BindGridCirculated(circulated.MemberNumber);
                }
                else
                {
                    MessageBox.Show("Error", "error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            btnBorrowCopy.IsEnabled = false;
        }
        #endregion


        // control return copy
        #region
        public void BindGridBorrowed(int num)
        {
            using (AccessData data = new AccessData())
            {
                ObservableCollection<CirculatedViewModel1> circulateds = new ObservableCollection<CirculatedViewModel1>(data.CirculatedRipository.GetAllCirculatedWithMemberNumber(num));
                dgBorrowed.ItemsSource = circulateds;
            }
        }

        private void btnCheck_Click(object sender, RoutedEventArgs e)
        {
            using (AccessData data = new AccessData())
            {

                bool ex = true;
                //check input type
                string? S = txtMemberNumber.Text;
                if (!int.TryParse(S, out int Num))
                {
                    MessageBox.Show("Error", "error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                //check member number and fill Data
                var item = data.MemberRipository.GetMemberModel2ById(Num, out ex);

                if (!ex)
                {
                    txtNameMember.Text = item.Name;
                    txtPhoneMember.Text = item.Telephone;
                    BindGridBorrowed(Num);
                }
                else
                {
                    MessageBox.Show("this Member Code does not exist !", "error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void btnConfirm_Click(object sender, RoutedEventArgs e)
        {
            if (dgBorrowed.SelectedIndex >= 0)
            {
                var item = dgBorrowed.SelectedItem as CirculatedViewModel1;
                txtAmount.Text = ConvertDate.DateToAmount(item.DueDate.Value, dpReturnDate.SelectedDate.Value).ToString();
                btnReturnBack.IsEnabled = true;
            }
        }

        private void btnReturnBack_Click(object sender, RoutedEventArgs e)
        {
            using (AccessData data = new AccessData())
            {
                var item = dgBorrowed.SelectedItem as CirculatedViewModel1;
                Circulated circulated = new Circulated()
                {
                    BorrowDate = item.BorrowDate,
                    DueDate = item.DueDate,
                    CopyNumber = item.CopyNumber,
                    CirculatedID = item.CirculatedID,
                    MemberNumber = item.MemberNumber,
                    ReturnDate = dpReturnDate.SelectedDate,
                    FineAmount = int.Parse(txtAmount.Text),
                };
                data.CirculatedRipository.UpdateCirculated(circulated);
                data.Save();
                BindGridBorrowed(item.MemberNumber);
                ChangeCopyType(item.CopyNumber, TypeN.Available);
                BindGridCopy();
                btnReturnBack.IsEnabled = false;
            }
        }

        private void dgBorrowed_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            btnReturnBack.IsEnabled = false;
            txtAmount.Text = "";
        }
        #endregion


        // control reservation
        #region
        public void BindGridReservation(int num)
        {
            using (AccessData data = new AccessData())
            {
                ObservableCollection<ReservationViewModel1> circulateds = new ObservableCollection<ReservationViewModel1>(data.ReservationRepository.GetReservationWithMemberNumber(num));
                dgResevation.ItemsSource = circulateds;
            }
        }

        private void btnCheckMemberCode_Click(object sender, RoutedEventArgs e)
        {
            using (AccessData data = new AccessData())
            {

                bool ex = true;
                //check input type
                string? S = txtMemberCode.Text;
                if (!int.TryParse(S, out int Num))
                {
                    MessageBox.Show("Error", "error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                //check member number and fill Data
                var item = data.MemberRipository.GetMemberModel2ById(Num, out ex);

                if (!ex)
                {
                    txtRNameMember.Text = item.Name;
                    txtRPhoneMember.Text = item.Telephone;
                    BindGridReservation(Num);
                }
                else
                {
                    MessageBox.Show("this Member Code does not exist !", "error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void btnCheckReseration_Click(object sender, RoutedEventArgs e)
        {
            using (AccessData data = new AccessData())
            {
                bool ex = true;
                //check input type
                string? S = txtRCopyNum.Text;
                if (!int.TryParse(S, out int Num))
                {
                    MessageBox.Show("Error", "error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                var item = data.CopyRipository.GetCopyById(Num);
                if (item != null)
                {
                    MessageBox.Show($"this copy is {(TypeN)item.Type} ", "Ohh!", MessageBoxButton.OK, MessageBoxImage.Information);
                    if ((TypeN)item.Type == TypeN.Available)
                    {
                        btnReseration.IsEnabled = true;
                    }
                    else
                    {
                        btnReseration.IsEnabled = false;
                    }
                }
                else
                {
                    MessageBox.Show("this Member Code does not exist !", "error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void btnReseration_Click(object sender, RoutedEventArgs e)
        {
            using (AccessData data = new AccessData())
            {
                Reservation reservation = new Reservation()
                {
                    Status = (int)StatusN.Reserved,
                    MemberNumber = int.Parse(txtMemberCode.Text),
                    Date = dpReservationDate.SelectedDate.Value,
                    CopyNumber = int.Parse(txtRCopyNum.Text),
                };
                ChangeCopyType(int.Parse(txtRCopyNum.Text), TypeN.Reserved);
                data.ReservationRepository.InsertReservation(reservation);
                data.Save();
                BindGridReservation(int.Parse(txtMemberCode.Text));
                btnReseration.IsEnabled = false;
            }

        }
        #endregion
    }
}