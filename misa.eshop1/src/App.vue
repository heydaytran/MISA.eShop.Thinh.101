<template>
  <div id="app">
    <Sidebar />
    
    <div class="body-right">
      <Header />
      <ShopManagement />
    </div>
  </div>
</template>

<script>
import ShopManagement from "./components/dictionary/ShopManagement.vue";
import Sidebar from "./components/layout/Sidebar.vue";
import Header from "./components/layout/Header.vue";

export default {
  name: "App",
  components: {
    ShopManagement,
    Header,
    Sidebar,
  },
};
</script>

<style>


@font-face {
    font-family: 'GoogleSans-Regular';
    src: url('~@/assets/font/GoogleSans-Regular.otf') format('opentype');
}

@font-face {
    font-family: 'GoogleSans-Light';
   src: url('~@/assets/font/GoogleSans-Light.otf') format('opentype');
}
@font-face {
    font-family: 'GoogleSans-Black';
   src: url('~@/assets/font/GoogleSans-Black.otf') format('opentype');
}

@font-face {
    font-family: 'GoogleSans-Thin';
  src: url('~@/assets/font/GoogleSans-Thin.otf') format('opentype');
}

#app {
  font-family: GoogleSans-Regular;
   font-size:13px;
    -webkit-font-smoothing: antialiased;
    -moz-osx-font-smoothing: grayscale;
    text-align: center;
    color: #2c3e50;
    display: flex;
}


.right-content-grid .x-panel .x-grid-table #table-store{
  
}
</style>
