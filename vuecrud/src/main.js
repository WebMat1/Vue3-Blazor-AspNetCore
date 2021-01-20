import { createApp } from 'vue'
import App from './App.vue'
import router from './router'
import { VuelidatePlugin } from '@vuelidate/core';

createApp(App).use(router).use(VuelidatePlugin).mount('#app')
