package com.hci.smarthypermarket;

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
	private Button buttonAddToOrder = null;
	
	private Shopper shopper = CartActivity.shopper;
	
	
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
		
		//set the layout
		
		if (shopper != null)
		{
			//show the product in the UI
			showProductDetails(shopper.getScannedProduct());
			
			//startCartActivity();
			
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
			Intent intent = new Intent(ProductActivity.this, CartActivity.class);
			startActivity(intent);
			return true;
		default:
			return super.onOptionsItemSelected(item);
		}
	}
	
	@Override
	public void showProductDetails(Product product) {
		
		  textViewProductName.setText(String.valueOf(product.getName()));
		  textViewProductPrice.setText(String.valueOf(product.getPrice()));
	 }

	@Override
	public void startCartActivity() {
		Intent intent = new Intent(ProductActivity.this, CartActivity.class);
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
		shopper.getOrder().getProducts().add(shopper.getScannedProduct());
		shopper.setScannedProduct(null);
		startCartActivity();
	}
}
