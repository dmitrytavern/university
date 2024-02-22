package com.example.work6

import androidx.compose.foundation.layout.Column
import androidx.compose.material3.Button
import androidx.compose.material3.Text
import androidx.compose.runtime.Composable
import androidx.compose.runtime.livedata.observeAsState
import com.example.work6.database.Employee

var nextId = 1

@Composable
fun AppMainScreen(
    model: MainViewModel
) {
    val data = model.getAllEmployees().observeAsState()

    Column {
        data.value?.let { list ->
            for (item in list) {
                Text(item.name)
            }
        }

        Button(onClick = {
            model.addEmployee(Employee(
                id = nextId,
                name = "Employee $nextId",
                experience = 1.2,
                email = "employee$nextId@gmail.com",
                phone = "+380487498234"
            ))

            nextId++
        }) {
            Text("Add new employee")
        }
    }
}
