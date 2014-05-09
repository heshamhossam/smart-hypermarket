package com.hci.smarthypermarket.views;

import com.hci.smarthypermarket.models.Product;


public interface IProductActivity {
	
	//show all product details in the GUI
	//@product : product to show its details in the GUI
	void showProductDetails(Product product);
	
	//go back to the cart activity and send the shopper object
	void startCartActivity();
	
	//show the number spinner to take the quantity of the product
	//@onClickHandler: handle the on click event of the submit button of the number input
	void showInputNumberPopup();
	
	void onBuyingProduct();
	
	void startDashBoardActivity();
	
	
}
