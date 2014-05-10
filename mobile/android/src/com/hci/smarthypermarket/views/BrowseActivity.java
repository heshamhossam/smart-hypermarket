package com.hci.smarthypermarket.views;

import java.util.List;

import com.hci.smarthypermarket.R;
import com.hci.smarthypermarket.models.Category;

import android.app.Activity;
import android.os.Bundle;
import android.widget.ArrayAdapter;
import android.widget.ListView;

public class BrowseActivity extends Activity {
	
	private ListView CategoryList;
	private List<Category> Values;
	@Override
	protected void onCreate(Bundle savedInstanceState){
		super.onCreate(savedInstanceState);
		setContentView(R.layout.activity_browse);
		
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

}
