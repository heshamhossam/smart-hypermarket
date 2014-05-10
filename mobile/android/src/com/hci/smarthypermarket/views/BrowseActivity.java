package com.hci.smarthypermarket.views;

import java.util.List;

import com.hci.smarthypermarket.R;
import com.hci.smarthypermarket.models.Category;

import android.app.ActionBar;
import android.app.Activity;
import android.content.Intent;
import android.graphics.Color;
import android.graphics.drawable.ColorDrawable;
import android.os.Bundle;
import android.view.Menu;
import android.view.MenuInflater;
import android.view.MenuItem;
import android.widget.ArrayAdapter;
import android.widget.ListView;

public class BrowseActivity extends Activity {
	
	private ListView CategoryList;
	private List<Category> Values;
	@Override
	protected void onCreate(Bundle savedInstanceState){
		super.onCreate(savedInstanceState);
		setContentView(R.layout.activity_browse);
		
		ActionBar ab = getActionBar(); 
        ColorDrawable colorDrawable = new ColorDrawable(Color.rgb(10, 73, 88));     
        ab.setBackgroundDrawable(colorDrawable);
       
        ab.setDisplayShowHomeEnabled(false);
		
		CategoryList = (ListView) findViewById(R.id.CategoryList);
		Values = LauncherActivity.market.getCategories();
		
		showCategories(Values);

	}

	public BrowseActivity() {
		
	}
	
	public void showCategories(List<Category> categories)
	{
		ArrayAdapter<Category> adpater = new CategoryAdapter(this, categories);
		CategoryList.setAdapter(adpater);
	}
	
	@Override
	public boolean onCreateOptionsMenu(Menu menu) {
		// Inflate the menu; this adds items to the action bar if it is present.
		MenuInflater mif = getMenuInflater();
		mif.inflate(R.menu.browse_actionbar, menu);
		return super.onCreateOptionsMenu(menu);
	}
	
	@Override
	public boolean onOptionsItemSelected(MenuItem item){
		switch(item.getItemId()){
		case R.id.home_icon:
			startDashBoardActivity();
		default:
			return super.onOptionsItemSelected(item);
		}
	}
	
	void startDashBoardActivity(){
		Intent intent = new Intent(BrowseActivity.this, DashBoardActivity.class);
		startActivity(intent);
	}

}
