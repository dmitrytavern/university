package com.example.exam

import androidx.compose.foundation.layout.Column
import androidx.compose.foundation.layout.fillMaxSize
import androidx.compose.foundation.layout.padding
import androidx.compose.material.icons.Icons
import androidx.compose.material.icons.filled.Menu
import androidx.compose.material3.*
import androidx.compose.runtime.Composable
import androidx.compose.runtime.MutableState
import androidx.compose.runtime.mutableStateOf
import androidx.compose.runtime.remember
import androidx.compose.runtime.rememberCoroutineScope
import androidx.compose.ui.Modifier
import androidx.compose.ui.unit.dp
import com.example.exam.viewmodels.MainViewModel
import com.example.exam.views.AboutScreen
import com.example.exam.views.DatabaseScreen
import com.example.exam.views.HomeScreen
import kotlinx.coroutines.launch

@OptIn(ExperimentalMaterial3Api::class)
@Composable
fun MainScreen(model: MainViewModel) {
    val drawerState = rememberDrawerState(initialValue = DrawerValue.Closed)
    val currentScreen = remember { mutableStateOf("home") }
    val scope = rememberCoroutineScope()

    ModalNavigationDrawer(
        drawerState = drawerState,
        drawerContent = {
            ModalDrawerSheet {
                Text("Меню", modifier = Modifier.padding(16.dp))
                HorizontalDivider()
                NavigationDrawerItem(
                    label = { Text(text = "Главная") },
                    onClick = { currentScreen.value = "home"; scope.launch { drawerState.apply { close() } } },
                    selected = false
                )
                NavigationDrawerItem(
                    label = { Text(text = "О приложении") },
                    onClick = { currentScreen.value = "about"; scope.launch { drawerState.apply { close() } }  },
                    selected = false
                )
                NavigationDrawerItem(
                    label = { Text(text = "Предметная область") },
                    onClick = { currentScreen.value = "database"; scope.launch { drawerState.apply { close() } }  },
                    selected = false
                )
            }
        }
    ) {
        Surface(modifier = Modifier.fillMaxSize()) {
            Scaffold(
                topBar = {
                    TopAppBar(
                        title = { Text(text = "Exam") },
                        navigationIcon = {
                            IconButton(onClick = {
                                scope.launch {
                                    drawerState.apply {
                                        if (isClosed) open() else close()
                                    }
                                }
                            }) {
                                Icon(Icons.Filled.Menu, contentDescription = "Меню")
                            }
                        }
                    )
                }
            ) { innerPadding ->
                ScreenContent(Modifier.padding(innerPadding), currentScreen, model)
            }
        }
    }
}

@Composable
fun ScreenContent(modifier: Modifier = Modifier, screen: MutableState<String>, model: MainViewModel) {
    Column(
        modifier = modifier.padding(16.dp)
    ) {
        when (screen.value) {
            "home" -> HomeScreen()
            "about" -> AboutScreen()
            "database" -> DatabaseScreen(model)
        }
    }
}
