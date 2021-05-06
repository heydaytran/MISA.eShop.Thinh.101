<template>
  <div>
    <div class="right-header">
      <div class="header-top">
        <div class="title">
          <div class="header-title">Cửa hàng</div>
        </div>
        <div class="store-user">
          <div class="header-select-store">
            <select name="" id="" class="store">
              <option value="">Chuỗi cửa hàng</option>
              <option value="">Kho tổng</option>
              <option value="">Misard</option>
              <option value="">Circle K</option>
            </select>
          </div>

          <div class="user">
            <div class="avatar"></div>
            <div data-v-146e2983="" name="userName" class="select-head">
              <select class="name">
                <option value="">Nguyễn Văn Mạnh</option>
              </select>
            </div>
          </div>
          <div class="support"></div>
          <div class="notify" style="position:relative">
              <div class="circle-red">

              </div>
          </div>
          <div class="help"></div>
        </div>
      </div>
    </div>
  </div>
</template>


<script>

export default {
  props: {
    hi: {
      type: String,
      default: "",
    },
  },
  data() {
    return {
      ok: "helloeveryone",
      datatoP: "",
    };
  },
  methods: {
    submit: function () {
      let datatoP = this.hi;
      this.$emit("send", datatoP);
      console.log("ham con" + datatoP);
    },
    busAddCustomer: function () {
      let dialogShow = true;
      console.log("đã vào hàm busAddCustomer" + dialogShow);

    },
  },
};
</script>


<style src ="../../style/layout/Header.scss" lang="scss" />


