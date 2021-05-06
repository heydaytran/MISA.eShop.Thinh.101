<template>
  <div>
    <div class="right-content">
      <div class="right-content-grid">
        <div class="remote-container">
          <div
            class="button-remote button-addCustomer"
            style="display: flex"
            @click="show"
          >
            <span
              data-ref="btnIconEl"
              role="presentation"
              unselectable="on"
              class="x-btn-icon icon-insert"
              style=""
            ></span>
            <div class="r-button boder-right">Thêm mới</div>
          </div>
          <div class="button-remote r-button boder-right">
            <span
              data-ref="btnIconEl"
              role="presentation"
              unselectable="on"
              class="x-btn-icon icon-btnclone"
              style=""
            ></span>
            <div class="text">Nhân bản</div>
          </div>
          <div
            class="button-remote"
            style="display: flex"
            @click="checkOneElement()"
          >
            <span
              data-ref="btnIconEl"
              role="presentation"
              unselectable="on"
              class="x-btn-icon icon-update"
              style=""
            ></span>
            <div class="r-button boder-right" style="display: flex">Sửa</div>
          </div>

          <div
            class="button-remote"
            style="display: flex"
            @click="showDeleteDialog()"
          >
            <span
              data-ref="btnIconEl"
              role="presentation"
              unselectable="on"
              class="x-btn-icon icon-delete"
              style=""
            ></span>
            <div class="r-button boder-right">Xóa</div>
          </div>
          <a href="" style="height: 36px">
            <div class="button-remote" style="display: flex" @click="reLoad()">
              <span
                data-ref="btnIconEl"
                role="presentation"
                unselectable="on"
                class="x-btn-icon icon-refresh"
                style=""
              ></span>
              <div class="r-button">Nạp</div>
            </div>
          </a>
        </div>
        <div class="x-panel">
          <div class="x-grid-table">
            <table cellpadding="0" cellspacing="0" id="table-store">
              <thead>
                <tr>
                  <th class="th-storeid">
                    <div class="x-column-header column-storeid">
                      <div class="x-column-header-inner">
                        <div class="x-fontw column-name">Mã cửa hàng</div>
                      </div>
                      <div class="x-column-header-condition">
                        <a href="" class="condition-btn"></a>
                        <input type="text" class="condition-text condition-storeCode" v-model="filter.filterStoreCode" @change="getdata()"/>
                      </div>
                    </div>
                  </th>
                  <th class="th-storename">
                    <div class="x-column-header column-storename">
                      <div class="x-column-header-inner">
                        <div class="x-fontw column-name">Tên cửa hàng</div>
                      </div>
                      <div class="x-column-header-condition">
                        <a href="" class="condition-btn"></a>
                        <input type="text" class="condition-text codition-storeName" v-model="filter.filterStoreName" @change="getdata()"/>
                      </div>
                    </div>
                  </th>
                  <th class="th-storeaddress">
                    <div class="x-column-header column-storeaddress">
                      <div class="x-column-header-inner">
                        <div class="x-fontw column-name">Địa chỉ</div>
                      </div>
                      <div class="x-column-header-condition">
                        <a href="" class="condition-btn"></a>
                        <input type="text" class="condition-text condition-address" v-model="filter.filterStoreAddress" @change="getdata()"/>
                      </div>
                    </div>
                  </th>
                  <th class="th-storenumber">
                    <div class="x-column-header column-storenumber">
                      <div class="x-column-header-inner">
                        <div class="x-fontw column-name">Số điện thoại</div>
                      </div>
                      <div class="x-column-header-condition">
                        <a href="" class="condition-btn"></a>
                        <input type="text" class="condition-text condition-phone" v-model="filter.filterStorePhoneNumber" @change="getdata()"/>
                      </div>
                    </div>
                  </th>
                  <th class="th-storestatus">
                    <div class="x-column-header column-storestatus">
                      <div class="x-column-header-inner">
                        <div class="x-fontw column-name">Trạng thái</div>
                      </div>
                      <div class="x-column-header-condition">
                        <input
                          type="text"
                          style="margin-left: 2px"
                          class="condition-text"
                          v-model="filter.filterStoreStatus"
                          @change="getdata()"
                        />
                      </div>
                    </div>
                  </th>
                </tr>
              </thead>
              <div v-show="!isLoaded" class="loading">
                <div class="loader"></div>
                <div class="text">Đang nạp dữ liệu</div>
              </div>

              <!-- <div  class="not-find">
                  <i class="notify">Không tìm thấy kết quả</i>
                </div> -->

              <tbody>
                <tr
                  v-for="shop in stores"
                  :key="shop.storeId"
                  @dblclick="showDetail(shop)"
                  @click="selectRow(shop.storeId)"
                  v-bind:class="selectedRow(shop.storeId) ? 'selected-row' : ''"
                >
                  <td>{{ shop.storeCode }}</td>
                  <td>{{ shop.storeName }}</td>
                  <td>{{ shop.address }}</td>
                  <td>{{ shop.phoneNumber }}</td>
                  <td>đang hoạt động</td>
                </tr>
              </tbody>
            </table>
          </div>
          <div class="x-grid-footer toolbar">
            <div class="paging-toolbar">
              <div class="leftchild">
                <div class="p-button first-page"></div>
                <div class="p-button prev-page"></div>
                <div style="margin: 0 16px 0 4px">Trang</div>
                <input type="text" value="1" class="text-pagebumber" />
                <div style="margin: 0 16px 0 6px">Trên 1</div>

                <div class="p-button next-page"></div>
                <div class="p-button last-page"></div>
                <div class="p-button refresh"></div>
                <select name="" id="" class="select-quantitypage">
                  <option value="">25</option>
                  <option value="">50</option>
                  <option value="">100</option>
                </select>
              </div>
              <div class="rightchild">
                <div class="noticenuber-paging">
                  Hiển thị 1 - 6 trên 6 kết quả
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>

    <ShopModalCreate
      ref="ShopModalCreate_ref"
      :store="store"
      :formMode="formMode"
    />
    <ShopModalDelete ref="ShopModalDelete_ref" :listSelectRow="listSelectRow" />
  </div>
</template>

<script>
import ShopModalCreate from "../modal/ShopManagement/ShopModalCreate.vue";
import ShopModalDelete from "../modal/ShopManagement/ShopModalDelete.vue";
import axios from "axios";

export default {
  components: {
    ShopModalCreate,
    ShopModalDelete,
  },
  methods: {
    // lấy dữ liệu các bản ghi shop
    // async getdata() {
    //   await axios
    //     .get("http://localhost:35480/api/v1/Stores")
    //     .then((Response) => {
    //       this.stores = Response.data.data;
    //       this.isLoaded = true;
    //     });
    // },

    async getdata() {
      await axios.get("http://localhost:35480/api/v1/Stores/Filter?storeName="+this.filter.filterStoreName
      +"&storeCode="+this.filter.filterStoreCode
      +"&address="+this.filter.filterStoreAddress
      +"&phoneNumber="+this.filter.filterStorePhoneNumber
      +"&status="+this.filter.filterStoreStatus)
      .then((Response) => {
          this.stores = Response.data.data;
          this.isLoaded = true;
        });
    },

    // hiển thị chi tiết bản ghi trên modal
    showDetail: async function (shop) {
      //this.store = shop;
      this.store = Object.assign({}, shop);

      // console.log(this.store, "a");
      // await ((this.store.storeCode = shop.storeCode),
      // (this.store.storeName = shop.storeName),
      // (this.store.address = shop.address),
      // (this.store.phoneNumber = shop.phoneNumber),
      // (this.store.storeTaxCode = shop.storeTaxCode),
      // (this.store.countryId = shop.countryId),
      // (this.store.wardId = shop.wardId),
      // (this.store.provinceId = shop.provinceId),
      // (this.store.districtId = shop.districtId),
      // (this.store.storeId = shop.storeId));
      this.$refs.ShopModalCreate_ref.showEditDialog();

      this.formMode = "edit";
      // this.$refs.selectedCountry = this.store.countryId;
      // this.$refs.selectedCity = this.store.provinceId;
    },

    show() {
      this.$refs.ShopModalCreate_ref.showAddDialog();
      this.formMode = "add";
    },

    //  select hàng, nếu hàng đã được select thì xóa khỏi mẩng listSelectRow, và ngược lại
    selectRow(id) {
      var index = this.listSelectRow.indexOf(id);
      if (index > -1) {
        this.listSelectRow.splice(index, 1);
        return true;
      } else {
        this.listSelectRow.push(id);
        return false;
      }
    },

    // kiểm tra hàng đã được select hay chưa
    selectedRow(id) {
      if (this.listSelectRow.indexOf(id) > -1) return true;
      else return false;
    },

    // hàm xóa bản ghi
    showDeleteDialog() {
      if (this.listSelectRow.length < 1) {
        alert("vui lòng chọn bản ghi");
        return;
      } else {
        this.$refs.ShopModalDelete_ref.show();
      }
    },

    // hàm tải lại dữ liệu cho trang
    reLoad() {
      this.getdata();
      this.listSelectRow = [];
    },

    // hàm kiểm tra mảng listSelectRow có đúng 1 phần tử hay không
    async checkOneElement() {
      var res = this;
      var quantity = this.listSelectRow.length;
      if (quantity > 1) {
        alert("Vui lòng sửa lần lượt từng bản ghi");
      } else if (quantity < 1) {
        alert("Vui lòng chọn bản ghi bạn muốn sửa");
      } else {
        await axios
          .get("http://localhost:35480/api/v1/stores/" + this.listSelectRow[0])
          .then((Response) => {
            res.showDetail(Response.data.data);
          });
      }
    },
  },

  data() {
    return {
      stores: [],
      store: {
        storeCode: "",
        storeName: "",
        address: "",
        phoneNumber: "",
        storeTaxCode: "",
        countryId: null,
        provinceId: null,
        districtId: null,
        wardId: null,
        status: 0,
        street: "",
        createDate: new Date(),
        createUserId: "149fb958744f70c67709bf1378b8dc91",
      },
      formMode: "add",
      listSelectRow: [],
      isLoaded: false,
      filter:{
        filterStoreName:"",
        filterStoreCode:"",
        filterStoreAddress:"",
        filterStoreStatus:0,
        filterStorePhoneNumber:""
      }

    };
  },
  created() {
    this.getdata();
  },
};
</script>

<style src="../../style/page/ShopManagement.scss" lang="scss"/>

<style scoped>
.selected-row {
  background: #a7afe4 !important;
}

.loading {
  width: calc(100% - 168px);
  height: calc(100vh - 209px);
  position: fixed;
  top: 165px;
  background-color: rgba(0, 0, 0, 0.3);
  color: #ffffff;
  text-align: center;
}
.loading .text {
  position: fixed;
  left: calc(50% + 20px);
  top: calc(50% + 90px);
}

.not-find {
  width: 100%;
  height: auto;
  text-align: center;
  background: transparent;
  position: absolute;
  line-height: 30px;
  font-weight: 500;
  font-size: 15px;
  margin-top: 8px;
}

.loader {
  position: fixed;
  left: 50%;
  top: 50%;
  font-size: 5px;
  width: 1em;
  height: 1em;
  border-radius: 50%;
  position: relative;
  text-indent: -9999em;
  -webkit-animation: load5 1.1s infinite ease;
  animation: load5 1.1s infinite ease;
  -webkit-transform: translateZ(0);
  -ms-transform: translateZ(0);
  transform: translateZ(0);
}

@keyframes load5 {
  0%,
  100% {
    box-shadow: 0em -2.6em 0em 0em #ffffff,
      1.8em -1.8em 0 0em rgba(255, 255, 255, 0.2),
      2.5em 0em 0 0em rgba(255, 255, 255, 0.2),
      1.75em 1.75em 0 0em rgba(255, 255, 255, 0.2),
      0em 2.5em 0 0em rgba(255, 255, 255, 0.2),
      -1.8em 1.8em 0 0em rgba(255, 255, 255, 0.2),
      -2.6em 0em 0 0em rgba(255, 255, 255, 0.5),
      -1.8em -1.8em 0 0em rgba(255, 255, 255, 0.7);
  }
  12.5% {
    box-shadow: 0em -2.6em 0em 0em rgba(255, 255, 255, 0.7),
      1.8em -1.8em 0 0em #ffffff, 2.5em 0em 0 0em rgba(255, 255, 255, 0.2),
      1.75em 1.75em 0 0em rgba(255, 255, 255, 0.2),
      0em 2.5em 0 0em rgba(255, 255, 255, 0.2),
      -1.8em 1.8em 0 0em rgba(255, 255, 255, 0.2),
      -2.6em 0em 0 0em rgba(255, 255, 255, 0.2),
      -1.8em -1.8em 0 0em rgba(255, 255, 255, 0.5);
  }
  25% {
    box-shadow: 0em -2.6em 0em 0em rgba(255, 255, 255, 0.5),
      1.8em -1.8em 0 0em rgba(255, 255, 255, 0.7), 2.5em 0em 0 0em #ffffff,
      1.75em 1.75em 0 0em rgba(255, 255, 255, 0.2),
      0em 2.5em 0 0em rgba(255, 255, 255, 0.2),
      -1.8em 1.8em 0 0em rgba(255, 255, 255, 0.2),
      -2.6em 0em 0 0em rgba(255, 255, 255, 0.2),
      -1.8em -1.8em 0 0em rgba(255, 255, 255, 0.2);
  }
  37.5% {
    box-shadow: 0em -2.6em 0em 0em rgba(255, 255, 255, 0.2),
      1.8em -1.8em 0 0em rgba(255, 255, 255, 0.5),
      2.5em 0em 0 0em rgba(255, 255, 255, 0.7), 1.75em 1.75em 0 0em #ffffff,
      0em 2.5em 0 0em rgba(255, 255, 255, 0.2),
      -1.8em 1.8em 0 0em rgba(255, 255, 255, 0.2),
      -2.6em 0em 0 0em rgba(255, 255, 255, 0.2),
      -1.8em -1.8em 0 0em rgba(255, 255, 255, 0.2);
  }
  50% {
    box-shadow: 0em -2.6em 0em 0em rgba(255, 255, 255, 0.2),
      1.8em -1.8em 0 0em rgba(255, 255, 255, 0.2),
      2.5em 0em 0 0em rgba(255, 255, 255, 0.5),
      1.75em 1.75em 0 0em rgba(255, 255, 255, 0.7), 0em 2.5em 0 0em #ffffff,
      -1.8em 1.8em 0 0em rgba(255, 255, 255, 0.2),
      -2.6em 0em 0 0em rgba(255, 255, 255, 0.2),
      -1.8em -1.8em 0 0em rgba(255, 255, 255, 0.2);
  }
  62.5% {
    box-shadow: 0em -2.6em 0em 0em rgba(255, 255, 255, 0.2),
      1.8em -1.8em 0 0em rgba(255, 255, 255, 0.2),
      2.5em 0em 0 0em rgba(255, 255, 255, 0.2),
      1.75em 1.75em 0 0em rgba(255, 255, 255, 0.5),
      0em 2.5em 0 0em rgba(255, 255, 255, 0.7), -1.8em 1.8em 0 0em #ffffff,
      -2.6em 0em 0 0em rgba(255, 255, 255, 0.2),
      -1.8em -1.8em 0 0em rgba(255, 255, 255, 0.2);
  }
  75% {
    box-shadow: 0em -2.6em 0em 0em rgba(255, 255, 255, 0.2),
      1.8em -1.8em 0 0em rgba(255, 255, 255, 0.2),
      2.5em 0em 0 0em rgba(255, 255, 255, 0.2),
      1.75em 1.75em 0 0em rgba(255, 255, 255, 0.2),
      0em 2.5em 0 0em rgba(255, 255, 255, 0.5),
      -1.8em 1.8em 0 0em rgba(255, 255, 255, 0.7), -2.6em 0em 0 0em #ffffff,
      -1.8em -1.8em 0 0em rgba(255, 255, 255, 0.2);
  }
  87.5% {
    box-shadow: 0em -2.6em 0em 0em rgba(255, 255, 255, 0.2),
      1.8em -1.8em 0 0em rgba(255, 255, 255, 0.2),
      2.5em 0em 0 0em rgba(255, 255, 255, 0.2),
      1.75em 1.75em 0 0em rgba(255, 255, 255, 0.2),
      0em 2.5em 0 0em rgba(255, 255, 255, 0.2),
      -1.8em 1.8em 0 0em rgba(255, 255, 255, 0.5),
      -2.6em 0em 0 0em rgba(255, 255, 255, 0.7), -1.8em -1.8em 0 0em #ffffff;
  }
}
</style>