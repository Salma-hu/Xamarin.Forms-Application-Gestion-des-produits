using ProductManagement.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ProductManagement
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            //base.OnAppearing();

            //Get All Produits
            var produitList = await App.SQLiteDb.GetItemsAsync();
            if (produitList != null)
            {
                lstProduits.ItemsSource = produitList.ToList();
            }
        }
        private async void BtnAdd_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtName.Text))
            {
                Produit produit = new Produit()
                {
                    Name = txtName.Text,
                    Description = txtDescription.Text,
                    Price = Convert.ToInt32(txtPrice.Text),


                };

                //Add New Produit
                await App.SQLiteDb.SaveItemAsync(produit);
                txtName.Text = string.Empty;
                await DisplayAlert("Success", "Produit added Successfully", "OK");
                //Get All Produits
                var produitList = await App.SQLiteDb.GetItemsAsync();
                if (produitList != null)
                {
                    lstProduits.ItemsSource = produitList;
                }
            }
            else
            {
                await DisplayAlert("Required", "Please Enter name!", "OK");
            }
        }

        private async void BtnRead_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtProduitId.Text))
            {
                //Get Produit
                var produit = await App.SQLiteDb.GetItemAsync(Convert.ToInt32(txtProduitId.Text));
                if (produit != null)
                {
                    txtName.Text = produit.Name;
                    await DisplayAlert("Success", "Produit Name: " + produit.Name, "OK");
                }
            }
            else
            {
                await DisplayAlert("Required", "Please Enter ProduitID", "OK");
            }
        }

        private async void BtnUpdate_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtProduitId.Text))
            {
                Produit produit = new Produit()
                {
                    Id = Convert.ToInt32(txtProduitId.Text),
                    Name = txtName.Text
                };

                //Update Produit
                await App.SQLiteDb.SaveItemAsync(produit);

                txtProduitId.Text = string.Empty;
                txtName.Text = string.Empty;
                await DisplayAlert("Success", "Produit Updated Successfully", "OK");
                //Get All Produits
                var produitList = await App.SQLiteDb.GetItemsAsync();
                if (produitList != null)
                {
                    lstProduits.ItemsSource = produitList;
                }

            }
            else
            {
                await DisplayAlert("Required", "Please Enter ProduitID", "OK");
            }
        }

        private async void BtnDelete_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtProduitId.Text))
            {
                //Get Produit
                var produit = await App.SQLiteDb.GetItemAsync(Convert.ToInt32(txtProduitId.Text));
                if (produit != null)
                {
                    //Delete Produit
                    await App.SQLiteDb.DeleteItemAsync(produit);
                    txtProduitId.Text = string.Empty;
                    await DisplayAlert("Success", "Produit Deleted", "OK");

                    //Get All Produits
                    var produitList = await App.SQLiteDb.GetItemsAsync();
                    if (produitList != null)
                    {
                        lstProduits.ItemsSource = produitList;
                    }
                }
            }
            else
            {
                await DisplayAlert("Required", "Please Enter ProduitID", "OK");
            }
        }

    }
}
