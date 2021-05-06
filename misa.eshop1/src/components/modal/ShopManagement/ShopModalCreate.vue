<template>
  <div>
    <BaseModal ref="BaseModal_ref">
      <div class="dialog-Customer">
        <div class="header-dialog">
          <div class="header-title">{{ formTitle }}</div>
          <div class="btn-close" @click="hide"></div>
        </div>
        <div class="body-dialog">
          <form action="#">
            <div class="dialog-content-top">
              <div class="input-row">
                <div class="ip-info-1">
                  <div class="label">Mã cửa hàng <span>*</span></div>
                  <input
                    type="text"
                    id="CustomerCode"
                    fieldName="CustomerCode"
                    class="m-input required"
                    ref="input_1"
                    v-model="store.storeCode"
                    @blur="ValidateEmty('input_1')"
                    @keyup="ValidateEmty('input_1')"
                  />
                  <!-- <ModalValidata
                    ref="ModalValidata_ref"
                    :validate="validateBag"
                    color="red"
                  /> -->
                </div>
                <ModalEmtyWarning
                  class="hidden"
                  :storeCodeValidate="storeCodeValidate"
                />
              </div>
              <div class="input-row">
                <div class="ip-info-1">
                  <div class="label">Tên cửa hàng <span>*</span></div>
                  <input
                    type="text"
                    id="CustomerName"
                    fieldName="FullName"
                    name="Customer-name"
                    class="m-input required"
                    ref="input_2"
                    v-model="store.storeName"
                    @blur="ValidateEmty('input_2')"
                    @keyup="ValidateEmty('input_2')"
                  />
                </div>
                <ModalEmtyWarning
                  class="hidden"
                  :storeCodeValidate="storeCodeValidate"
                />
                <div class="input-row"></div>
              </div>
              <div class="input-row">
                <div class="ip-info-1">
                  <div class="label lb-address">Địa chỉ <span>*</span></div>
                  <textarea
                    class="area-address required"
                    aria-hidden="false"
                    aria-disabled="false"
                    aria-multiline="true"
                    role="textbox"
                    v-model="store.address"
                    aria-invalid="false"
                    aria-readonly="false"
                    aria-describedby="MISATextAreaField-1221-ariaStatusEl"
                    aria-required="true"
                    autocomplete="off"
                    data-componentid="MISATextAreaField-1221"
                    ref="input_3"
                    @blur="ValidateEmty('input_3')"
                    @keyup="ValidateEmty('input_3')"
                  ></textarea>
                </div>
                <ModalEmtyWarning
                  class="hidden"
                  :storeCodeValidate="storeCodeValidate"
                />
                <div class="input-row"></div>
              </div>
            </div>

            <div class="dialog-content-bottom">
              <div class="input-row">
                <div class="ip-info-2">
                  <div class="b-input input-phone">
                    <div class="label">Số điện thoại</div>
                    <input
                      type="text"
                      class="text-phone"
                      v-model="store.phoneNumber"
                    />
                  </div>
                  <div class="b-input input-tax">
                    <div class="label">Mã số thuế</div>
                    <select class="m-input text-tax">
                      <option>{{ store.storeTaxCode }}</option>
                    </select>
                  </div>
                </div>
              </div>
              <div class="input-row">
                <div class="ip-info-2">
                  <div class="b-input input-country">
                    <div class="label">Quốc gia</div>
                    <select
                      class="m-input select-country"
                      v-model="selectedCountry"
                    >
                      <option :value="null" selected>--Quốc gia--</option>
                      <option
                        v-for="option in optionCountry"
                        :key="option.value"
                        v-bind:value="option.value"
                      >
                        {{ option.text }}
                      </option>
                    </select>
                  </div>
                </div>
              </div>
              <div class="input-row">
                <div class="ip-info-2">
                  <div class="b-input input-province">
                    <div class="label">Tỉnh/Thành phố</div>
                    <select
                      class="m-input select-province"
                      v-model="selectedCity"
                    >
                      <option :value="null" selected>--Tỉnh/Thành phố--</option>
                      <option
                        :value="city.value"
                        v-for="city in optionCity"
                        :key="city.value"
                      >
                        {{ city.text }}
                      </option>
                    </select>
                  </div>
                  <div class="b-input input-distric">
                    <div class="label">Quận/Huyện</div>
                    <select
                      class="m-input select-distric"
                      v-model="selectedDistrict"
                    >
                      <option :value="null" selected>--Quận/Huyện--</option>
                      <option
                        :value="district.value"
                        v-for="district in optionDistrict"
                        :key="district.value"
                      >
                        {{ district.text }}
                      </option>
                    </select>
                  </div>
                </div>
              </div>
              <div class="input-row">
                <div class="ip-info-2">
                  <div class="b-input input-village">
                    <div class="label">Phường/Xã</div>
                    <select
                      class="m-input select-village"
                      v-model="selectedWard"
                    >
                      <option :value="null" selected>--Phường/Xã--</option>
                      <option
                        :value="ward.value"
                        v-for="ward in optionWard"
                        :key="ward.value"
                      >
                        {{ ward.text }}
                      </option>
                    </select>
                  </div>
                  <div class="b-input input-street">
                    <div class="label">Đường phố</div>
                    <select class="m-input text-street"></select>
                  </div>
                </div>
              </div>
            </div>
          </form>
        </div>
        <div class="dialog-footer">
          <div class="leftchild">
            <div class="d-button dbtn-support">
              <div class="icon"></div>
              <div class="text-support">Trợ giúp</div>
            </div>
          </div>
          <div class="rightchild">
            <div class="d-button dbtn-save" @click="save('addOne')">
              <div class="icon"></div>
              <div class="text-support">Lưu</div>
            </div>
            <div class="d-button dbtn-get" @click="save('addMore')">
              <div class="icon"></div>
              <div class="text-support">Lưu và thêm mới</div>
            </div>
            <div class="d-button dbtn-cancle" @click="hide">
              <div class="icon"></div>
              <div class="text-support">Hủy bỏ</div>
            </div>
          </div>
        </div>
      </div>
    </BaseModal>
  </div>
</template>

<script>
import BaseModal from "../BaseModalForm.vue";
import axios from "axios";
import ModalEmtyWarning from "../ModalEmtyWarning.vue";

export default {
  components: {
    BaseModal,
    ModalEmtyWarning,
  },
  props: ["store", "formMode"],
  methods: {
    //reset lại giá trị dialog
    resetInput() {
      this.store.storeCode = "";
      this.store.storeName = "";
      this.store.address = "";
      this.optionCity = [];
      this.optionDistrict = [];
      this.optionWard = [];
      this.selectedCountry = null;
      this.selectedCity = null;
      this.selectedDistrict = null;
      this.selectedWard = null;
    },

    // hiện dialog thêm
    showAddDialog() {
      this.$refs.BaseModal_ref.show();
      this.resetInput();
      setTimeout(() => {
        document.getElementById("CustomerCode").focus();
      }, 0);
      this.getCounTryData();
      this.formTitle = "Thêm mới cửa hàng";
    },

    // hiện dialog sửa
    showEditDialog: async function () {
      this.$refs.BaseModal_ref.show();
       this.selectedCountry = null;
   

      this.formTitle = "Chỉnh sửa cửa hàng";
      await this.getCounTryData();
      this.selectedCountry = this.store.countryId;
    },

    // ẩn dialog
    hide() {
      this.$refs.BaseModal_ref.hide();
    },

    //lấy danh sách quốc gia
    getCounTryData: async function () {
      const response = await axios.get(
        "http://localhost:35480/api/v1/Countrys"
      );
      var optionCountry = [];
      response.data.data.forEach(function (item) {
        optionCountry.push({
          text: item.countryName,
          value: item.countryId,
        });
      });
      this.optionCountry = optionCountry;
    },

    // lấy danh sách tỉnh theo quốc gia
    getProvince: async function () {
      const response = await axios.get(
        "http://localhost:35480/api/v1/Provinces/WithCountry/" +
          this.selectedCountry
      );

      var optionCity = [];
      response.data.data.forEach(function (item) {
        optionCity.push({
          text: item.provinceName,
          value: item.provinceId,
        });
      });
      this.optionCity = optionCity;
    },

    //lấy danh sách huyện theo tỉnh
    getDistrict: async function () {
      const response = await axios.get(
        "http://localhost:35480/api/v1/Districts/WithProvince/" +
          this.selectedCity
      );

      var optionDistrict = [];
      response.data.data.forEach(function (item) {
        optionDistrict.push({
          text: item.districtName,
          value: item.districtId,
        });
      });
      this.optionDistrict = optionDistrict;
    },

    //lấy danh sách phường xã theo huyện
    getWard: async function () {
      const response = await axios.get(
        "http://localhost:35480/api/v1/Wards/WithDistrict/" +
          this.selectedDistrict
      );

      var optionWard = [];
      response.data.data.forEach(function (item) {
        optionWard.push({
          text: item.wardName,
          value: item.wardId,
        });
      });
      this.optionWard = optionWard;
    },

    async save(text) {
      this.store.wardId = this.selectedWard;
      this.store.countryId = this.selectedCountry;
      this.store.provinceId = this.selectedCity;
      this.store.districtId = this.selectedDistrict;

      var res = this;
      var vali = await res.validateForm();
      if (vali == false) {
        alert("Vui lòng kiểm tra lại các trường đã nhập");
        return;
      }

      switch (this.formMode) {
        case "add": {
          await axios
            .post("http://localhost:35480/api/v1/Stores/", this.store)
            .then((respone) => {
              if (text == "addOne") {
                res.hide();
                // console.log(respone, "dlieu tra ve khi post");
                //alert(respone.data.userMsg)
              } else res.resetInput();
              alert(respone.data.userMsg);
            })
            .catch((error) => {
              console.log(error, "Lỗi xảy ra");
              alert("Có lỗi xảy ra, vui lòng liên hệ MISA để được trợ giúp");
            });
          break;
        }
        case "edit": {
          await axios
            .put(
              `http://localhost:35480/api/v1/stores/${res.store.storeId}`,
              res.store
            )
            .then((response) => {
              if (text == "addOne") {
                res.hide();
                console.log(response, "dữ liệu trả về khi sửa");
              } else {
                res.resetInput();
                res.formMode = "add"
              }
              alert(response.data.userMsg);
            });
          break;
        }
      }
    },

    // check các input bắt buộc nhập có null không
    ValidateEmty(input) {
      var res = this.$refs[input];
      if (res.value == "") {
        res.classList.add("boderRed");
        // var h = document.getElementById("hidden1");
        // h.classList.remove("hidden");
        res.parentElement.nextSibling.classList.remove("hidden");

        // var phanTuCon = document.getElementById("hidden1");
        // phanTuCon.parentNode.removeChild(phanTuCon);
        //  this.$refs.ModalValidata_ref.show()
      } else {
        res.classList.remove("boderRed");
        res.parentElement.nextSibling.classList.add("hidden");
      }
    },

    //validate toàn bộ form nhập khi ấn lưu
    async validateForm() {
      this.storeCodeValidate = "Trường này không được bỏ trống"
      var res = this;
      var requiredInput = document.getElementsByClassName("required");
      var validateForm = true;

      for (let i = 0; i < requiredInput.length; i++) {
        if (requiredInput[i]._value === "") {
          validateForm = false;
          requiredInput[i].classList.add("boderRed");
          requiredInput[i].parentElement.nextSibling.classList.remove("hidden");
          continue;
        }
      }

    if(validateForm == true)
    {
        if (
        requiredInput[0]._value != "" &&
        requiredInput[1]._value != "" &&
        requiredInput[2]._value != ""
      ) {
        validateForm = await res.checkDuplicateCode(res.store.storeCode);
        if (validateForm === false) {
          requiredInput[0].classList.add("boderRed");
          // res.storeCodeFake = "";
          this.storeCodeValidate = "Mã cửa hàng bị trùng";
          requiredInput[0].parentElement.nextSibling.classList.remove("hidden");
        }
        else {
          this.storeCodeValidate = ""
        }
      }
    }

      return validateForm;
    },

    // check trùng mã
    async checkDuplicateCode(storeCode) {
      var res = this;

      await axios
        .get("http://localhost:35480/api/v1/stores/getbycode", {
          params: {
            storeCode: storeCode,
          },
        })
        .then((respone) => {
          if (respone.data.errorCode == 400) {
            if (this.formMode == "edit") {
              if (respone.data.data.storeId != res.store.storeId) {
                res.checkDup = false;
              } else {
                res.checkDup = true;
              }
            } else {
              res.checkDup = false;
              alert("mã cửa hàng đã tồn tại");
            }
          } else {
            res.checkDup = true;
          }
          return res.checkDup;
        })
        .catch((error) => {
          console.log(error);
        });

      return res.checkDup;
    },

    //hàm reset lại các giá trị địa chỉ
    resetLocation() {
      this.selectedCity = null;
      this.selectedDistrict = null;
      this.selectedWard = null;
      this.optionCity = [];
      this.optionDistrict = [];
      this.optionWard = [];
    },
  },
  computed: {},

  data() {
    return {
      selectedCountry: 0,

      optionCountry: [],
      selectedCity: 0,
      optionCity: [],
      selectedDistrict: 0,
      optionDistrict: [],
      optionWard: [],
      selectedWard: 0,
      formTitle: "Thêm mới cửa hàng",
      storeCodeValidate: "Trường này không được bỏ trống",
      checkDup: true,
      //storeCodeFake: this.store.storeCode
    };
  },

  watch: {
    // theo dõi biến chọn quốc gia
    selectedCountry: async function () {
      //var res = this
      // this.store.countryId = this.selectedCountry

      this.optionCity = [];
      this.selectedCity = null;

      if (this.selectedCountry != null) {
        await this.getProvince();
        if (this.formMode == "edit") {
          // xét xem store.provinceID có trong mảng optionCity hay không
          var optionCity = this.optionCity;
          var index = optionCity
            .map(function (e) {
              return e.value;
            })
            .indexOf(this.store.provinceId);

          if (index > -1) {
            this.selectedCity = this.store.provinceId;
          }
        }
      }

      
    },

    // theo dõi biến chọn tỉnh
    selectedCity: async function () {
      this.optionDistrict = [];
      this.selectedDistrict = null;

      if (this.selectedCity != null) {
        await this.getDistrict();

        if (this.formMode == "edit") {
          // xét xem store.provinceID có trong mảng optionCity hay không
          var optionDistrict = this.optionDistrict;
          var index = optionDistrict
            .map(function (e) {
              return e.value;
            })
            .indexOf(this.store.districtId);

          if (index > -1) {
            this.selectedDistrict = this.store.districtId;
          }
        }
      }
    },

    // theo dõi biến chọn huyện
    selectedDistrict: async function () {

      this.optionWard = [];
      this.selectedWard = null;

      if (this.selectedDistrict != null) {
        await this.getWard();
        
         if (this.formMode == "edit") {
          // xét xem store.wardID có trong mảng optionWard hay không
          var optionWard = this.optionWard;
          var index = optionWard
            .map(function (e) {
              return e.value;
            })
            .indexOf(this.store.wardId);

          if (index > -1) {
            this.selectedWard = this.store.wardId;
          }
        }
      } 

      
    },

    // theo dõi biến chọn xã
    // selectedWard: async function(){
    //   if(this.selectedWard != null)
    //   {
    //     this.store.wardId  = this.selectedWard
    //   }
    //   else this.store.wardId = null
    // }
  },
};
</script>

<style src="../../../style/common/_ShopModalCreate.scss" lang="scss" />
<style scoped>
.hidden {
  opacity: 0;
}
</style>




