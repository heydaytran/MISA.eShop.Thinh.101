<template>
  <div>
    <BaseModalForm ref="BaseModalForm_ref">
      <div class="dialog-Customer1">
        <div class="modal-delete-container">
          <div class="modal-delete">
            <div class="modal-delete-header">Xóa dữ liệu</div>
            <div class="modal-delete-content">
              <div class="icon"></div>
              <div class="content">
                <span>Bạn có chắc chắn muốn xóa các cửa hàng đã chọn?</span>
              </div>
            </div>
            <div class="modal-delete-footer">
              <div class="footer-button">
                <div class="delete-button" @click="confirm()">
                  <div class="icon-delete"></div>
                  <span>Xóa</span>
                </div>
                <div class="cancle-button" @click="hide()">Hủy bỏ</div>
              </div>
            </div>
          </div>
        </div>
      </div>
    </BaseModalForm>
  </div>
</template>

<script>
import axios from "axios";
import BaseModalForm from "../BaseModalForm.vue";

export default {
  props: {
    listSelectRow: Array,
  },
  data() {
    return {};
  },
  components: {
    BaseModalForm,
  },
  methods: {
    show() {
      this.$refs.BaseModalForm_ref.show();
    },
    hide() {
      this.$refs.BaseModalForm_ref.hide();
    },
    async confirm() {
      var res = this
      for (var i = 0; i < this.listSelectRow.length; i++) {
        await axios
          .delete(
            "http://localhost:35480/api/v1/Stores/" +
            this.listSelectRow[i]
          )
          .then((Response) => {

            if(Response.data.isSuccess == true)
            {
              
              res.hide()
            }
          })
          .catch((err)=>{
            console.log(err);
            alert("Có lỗi xảy ra, vui lòng liên hệ MISA để được trợ giúp")
            return
          })
      }
      alert("Đã xóa thành công")
    },
  },
};
</script>


<style scoped>
.modal-delete-container {
  z-index: 1000;

  border-radius: 5px;
  position: absolute;
  top: calc(50% - 300px);
  left: calc(50% - 350px);
  border: 2px solid #e5e6e5;
}
.modal-delete {
  height: 156px;
  width: 400px;
  position: relative;
  color: black;
  background: white;
}

.modal-delete-header {
  background: #f0f0f0;
  height: 20px;
  width: calc(396px - 28px);
  padding: 10px 16px;
}

.modal-delete-footer {
  height: 48px;
  bottom: 0px;
}

.modal-delete-content {
  height: calc(100% - 48px - 40px);
}

.modal-delete-content {
  display: flex;
  align-items: center;
}

.modal-delete-content .icon {
  width: 44px;
  height: 44px;
  background-image: url(data:image/png;base64,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);
  background-position: -165px -2px;
}

.modal-delete-header {
  font-size: 16px;
  text-align: left;
  color: black;
  font-weight: 700;
}

.modal-delete-footer {
  display: flex;
  align-items: center;
}

.modal-delete-footer .delete-button {
  background: red;
  height: 18px;
  width: 58px;
  padding: 7px;
  cursor: pointer;
  display: flex;
  border-radius: 4px;
  align-items: center;
}

.modal-delete-footer .cancle-button {
  height: 18px;
  width: 58px;
  cursor: pointer;
  display: flex;
  align-items: center;
  padding: 7px;
}

.footer-button {
  display: flex;
  position: absolute;
  right: 0;
}

.footer-button .icon-delete {
  background-image: url("../../../assets/icon/common-icon.png");
  background-position: -1077px -128px;
  height: 16px;
  width: 16px;
  margin-right: 5px;
}
</style>