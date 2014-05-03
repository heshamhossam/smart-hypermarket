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
import android.util.Log;
import android.view.Menu;
import android.view.MenuInflater;
import android.view.MenuItem;
import android.view.View;
import android.view.View.OnClickListener;
import android.widget.Button;
import android.widget.EditText;
import android.widget.LinearLayout;
import android.widget.ListView;
import android.widget.Toast;

@SuppressLint("NewApi")
public class CartActivity extends Activity implements ICartActivity {
	
	private Shopper shopper = LauncherActivity.shopper;
	private Button fireOrder;

	@TargetApi(Build.VERSION_CODES.HONEYCOMB)
	@SuppressLint("NewApi")
	@Override
	protected void onCreate(Bundle savedInstanceState) {
		// TODO Auto-generated method stub
		super.onCreate(savedInstanceState);
		setContentView(R.layout.activity_main);
		
		//set action bar
		ActionBar ab = getActionBar(); 
        ColorDrawable colorDrawable = new ColorDrawable(Color.rgb(10, 73, 88));     
        ab.setBackgroundDrawable(colorDrawable);
        ab.setDisplayShowHomeEnabled(false);
		
		shopper.getOrder().showProductsItems(CartActivity.this, (ListView) findViewById(R.id.listViewProducts));
		
		
		//startProductActivity();
		
		
		//start the product activity and send the shopper in the intent
		//startProductActivity(shopper);

		fireOrder = (Button) findViewById(R.id.buttonFireOrder);
		fireOrder.setOnClickListener(new OnClickListener() {
			@Override
			public void onClick(View arg0) {
				getUsersPaymentsDetails();
				
			}
		});
		
		
	}
	
	@Override
	public boolean onCreateOptionsMenu(Menu menu) {
		// Inflate the menu; this adds items to the action bar if it is present.
		MenuInflater mif = getMenuInflater();
		mif.inflate(R.menu.main, menu);
		return super.onCreateOptionsMenu(menu);
	}
	
	@Override
	public boolean onOptionsItemSelected(MenuItem item){
		switch(item.getItemId()){
		case R.id.home_icon:
			startDashBoardActivity();
			return true;
		default:
			return super.onOptionsItemSelected(item);
		}
	}

	@Override
	public void startDashBoardActivity() {
		// TODO Auto-generated method stub
		Intent intent = new Intent(CartActivity.this, DashBoardActivity.class);
		startActivity(intent);
		
	}
	
	public void startProductActivity() {
		// TODO Auto-generated method stub
		Intent intent = new Intent(CartActivity.this, ProductActivity.class);
		startActivity(intent);
		
	}

	private void getUsersPaymentsDetails(){
		final AlertDialog.Builder alert = new AlertDialog.Builder(this);
		
		LinearLayout linear = new LinearLayout(this);
		linear.setOrientation(1); // 1 is for vertical orientation
		final EditText fname = new EditText(this);
		fname.setHint("First Name");
		final EditText lname = new EditText(this);
		lname.setHint("Last Name");
		final EditText creditcard = new EditText(this);
		creditcard.setHint("Credit Card");
		linear.addView(fname);
		linear.addView(lname);
		linear.addView(creditcard);
		
		alert.setView(linear);
		alert.setTitle("Payment Details");
		
		alert.setPositiveButton("Send", new DialogInterface.OnClickListener() {
			
			@Override
			public void onClick(DialogInterface dialog, int which) {
				shopper.setFirstName(fname.getText().toString());
				shopper.setLastName(lname.getText().toString());
				shopper.submitOrder();
				Toast.makeText(getApplicationContext(), "Order Sent to" + shopper.getMobile(), Toast.LENGTH_LONG).show();
			    finish();
				
			}
		});
		
		alert.setNegativeButton("Cancel", new DialogInterface.OnClickListener() {
			
			@Override
			public void onClick(DialogInterface dialog, int which) {
				// TODO Auto-generated method stub
				Toast.makeText(getApplicationContext(), "Cancel Done", Toast.LENGTH_LONG).show();
			    finish();
			}
		});
		
		AlertDialog alertDialog = alert.create();
		alertDialog.show();
	}



}
