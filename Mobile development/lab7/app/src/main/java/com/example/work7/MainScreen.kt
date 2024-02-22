package com.example.work7

import androidx.compose.foundation.layout.Column
import androidx.compose.material3.Button
import androidx.compose.material3.Text
import androidx.compose.runtime.Composable
import androidx.compose.runtime.mutableStateOf
import androidx.compose.runtime.remember

@Composable
fun MainScreen() {
    val text = remember { mutableStateOf("Button was not clicked.") }
    val buttonText = remember { mutableStateOf("Click me!") }

    Column {
        Text("Hello world")

        Text(text.value)

        Button(onClick = {
            text.value = "Button was clicked."
            buttonText.value = "Thanks!"
        }) {
            Text(buttonText.value)
        }
    }
}
