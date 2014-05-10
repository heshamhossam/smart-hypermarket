package com.hci.smarthypermarket.views;

import org.w3c.dom.Text;

import com.hci.smarthypermarket.R;
import com.hci.smarthypermarket.R.id;
import com.hci.smarthypermarket.R.layout;
import com.hci.smarthypermarket.R.menu;
import com.hci.smarthypermarket.models.Product;
import com.hci.smarthypermarket.models.Shopper;

import android.annotation.SuppressLint;
import android.annotation.TargetApi;
import android.app.ActionBar;
import android.app.Activity;
import android.app.AlertDialog;
import android.content.DialogInterface;
import android.content.Intent;
import android.graphics.Color;
import android.graphics.drawable.ColorDrawable;
import android.os.Build;
import android.os.Bundle;
import android.view.Menu;
import android.view.MenuInflater;
import android.view.MenuItem;
import android.view.View;
import android.view.View.OnClickListener;
import android.widget.Button;
import android.widget.LinearLayout;
import android.widget.SeekBar;
import android.widget.SeekBar.OnSeekBarChangeListener;
import android.widget.TextView;
import android.widget.Toast;

@SuppressLint("NewApi")
public class ProductActivity extends Activity implements IProductActivity {
	
	private TextView textViewProductName = null;
	private TextView textViewProductPrice = null;
	private TextView textViewProductWeight = null;
	private TextView textVieewProductDescription = null;
	private TextView textViewProductBrand = null;
	private Button buttonAddToOrder = null;
	
	private Shopper shopper = LauncherActivity.shopper;
	
	
	@TargetApi(Build.VERSION_CODES.HONEYCOMB)
	@SuppressLint("NewApi")
	@Override
	protected void onCreate(Bundle savedInstanceState) {
		// TODO Auto-generated method stub
		super.onCreate(savedInstanceState);
		setContentView(R.layout.activity_product);
		
		ActionBar ab = getActionBar(); 
        ColorDrawable colorDrawable = new ColorDrawable(Color.rgb(10, 73, 88));     
        ab.setBackgroundDrawable(colorDrawable);
       
        ab.setDisplayShowHomeEnabled(false);
		
		textViewProductName = (TextView) findViewById(R.id.itemName);
		textViewProductPrice = (TextView) findViewById(R.id.itemPrice);
		textVieewProductDescription = (TextView) findViewById(R.id.itemDescription);
		textViewProductBrand = (TextView) findViewById(R.id.itemBrand);
		textViewProductWeight = (TextView) findViewById(R.id.itemWeight);
		//set the layout
		
		if (shopper != null)
		{
			
			//show the product in the UI
			showProductDetails(shopper.getScannedProduct());
			
			//when add product to cart button is clicked
			buttonAddToOrder = (Button) findViewById(R.id.addButton);
			buttonAddToOrder.setOnClickListener(new OnClickListener() {
				
				@Override
				public void onClick(View v) {
					showInputNumberPopup();
					
				}
			});
			
		}
		
		
	}
	
	public void showReviewForm()
	{
		//implement this function so you show a review form contains big text box which is the body of the review
	}
	
	public void showReviews(Product product)
	{
		//implement this function to view three of the reviews
		//product contains list of reviews use product.getReviews()
		
	}
	
	@Override
	public boolean onCreateOptionsMenu(Menu menu) {
		// Inflate the menu; this adds items to the action bar if it is present.
		MenuInflater mif = getMenuInflater();
		mif.inflate(R.menu.product_actionbar, menu);
		return super.onCreateOptionsMenu(menu);
	}
	
	@Override
	public boolean onOptionsItemSelected(MenuItem item){
		switch(item.getItemId()){
		case R.id.back_icon:
			startCartActivity();
			return true;
		case R.id.home_icon:
			startDashBoardActivity();
		default:
			return super.onOptionsItemSelected(item);
		}
	}
	
	
	@Override
	public void showProductDetails(Product product) {
		
		  textViewProductName.setText(String.valueOf(product.getName()));
		  textViewProductPrice.setText(String.valueOf(product.getPrice()));
		  textVieewProductDescription.setText(String.valueOf(product.getDescription()));
		  
		  textViewProductBrand.setText(String.valueOf("Drinks"));
		  textViewProductWeight.setText(String.valueOf(product.getWeight()));
	 }

	@Override
	public void startCartActivity() {
		Intent intent = new Intent(ProductActivity.this, CartActivity.class);
		startActivity(intent);
	}
	
	@Override
	public void startDashBoardActivity(){
		Intent intent = new Intent(ProductActivity.this, DashBoardActivity.class);
		startActivity(intent);
	}

	public void showInputNumberPopup() {
		  // TODO Auto-generated method stub
		  final AlertDialog.Builder alertdlg = new AlertDialog.Builder(this);
		  alertdlg.setTitle("Quantity");
		  alertdlg.setMessage("Pick up the Quantity!");
		  
		  LinearLayout linear = new LinearLayout(this);
		  linear.setOrientation(1);
		  
		  SeekBar seekBar = new SeekBar(this);
		  seekBar.setMax(10);
		  final TextView seekBarResult = new TextView(this);
		  
		  seekBarResult.setText(seekBar.getProgress() + "/" + seekBar.getMax());
		        seekBar.setOnSeekBarChangeListener(new OnSeekBarChangeListener(){
		         public void onProgressChanged(SeekBar seekbar, int ProgressValue, boolean fromUser){
		          shopper.getScannedProduct().setPurchasedQuantity(ProgressValue);
		         }
		         @Override
		            public void onStartTrackingTouch(SeekBar seekBar){
		          
		         }
		         @Override
		            public void onStopTrackingTouch(SeekBar seekBar){
		          seekBarResult.setText(shopper.getScannedProduct().getPurchasedQuantity() + "/" + seekBar.getMax());
		         }
		        });
		        
		        linear.addView(seekBar);
		        linear.addView(seekBarResult);
		        
		        alertdlg.setView(linear);
		        
		        alertdlg.setPositiveButton("Add", new DialogInterface.OnClickListener() {
		   
		   @Override
		   public void onClick(DialogInterface dialog, int which) {
			   onBuyingProduct();
		   }
		  });
		        alertdlg.setNegativeButton("Cancel", new DialogInterface.OnClickListener() {
		   
		   @Override
		   public void onClick(DialogInterface dialog, int which) {
		    // TODO Auto-generated method stub
		    Toast.makeText(getApplicationContext(), "Cancel Pressed", Toast.LENGTH_LONG).show();
		    finish();
		   }
		  });
		        
		        AlertDialog alertDialog = alertdlg.create();
		  alertDialog.show();
		 }

	@Override
	public void onBuyingProduct() {
		shopper.getOrder().addProduct(shopper.getScannedProduct());
		shopper.setScannedProduct(null);
		startCartActivity();
	}
}
